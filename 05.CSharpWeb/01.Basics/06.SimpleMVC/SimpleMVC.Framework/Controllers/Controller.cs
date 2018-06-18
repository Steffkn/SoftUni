namespace SimpleMVC.Framework.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using SimpleMVC.Framework.ActionResults;
    using SimpleMVC.Framework.Attributes.Properties;
    using SimpleMVC.Framework.Interfaces;
    using SimpleMVC.Framework.Models;
    using SimpleMVC.Framework.Security;
    using SimpleMVC.Framework.Views;
    using WebServer.Http;
    using WebServer.Http.Contracts;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
            this.User = new Authentication();
        }

        protected ViewModel Model { get; }

        protected internal IHttpRequest Request { get; internal set; }

        protected internal Authentication User { get; private set; }

        // Generate the view for the method that called that View() method. For example, if method Index() in HomeController class call that View() method it would instantiate <assembly>.Views.Home.Index.cs class
        protected IViewable View([CallerMemberName]string caller = "")
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Get.ControllersSuffix, string.Empty);
            string fullyQualifiedName = string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ViewsFolder,
                controllerName,
                caller);
            IRenderable view = new View(fullyQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected bool IsValidModel(object bindingModel)
        {
            foreach (var property in bindingModel.GetType().GetProperties())
            {
                IEnumerable<Attribute> attributes = property.GetCustomAttributes().Where(a => a is PropertyAttribute);

                if (!attributes.Any())
                {
                    continue;
                }

                foreach (var attribute in attributes)
                {
                    if (!(attribute as PropertyAttribute).IsValid(property.GetValue(bindingModel)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected internal void InitializeController()
        {
            var user = this.Request
                .Session
                .Get<string>(SessionStore.CurrentUserKey);

            if (user != null)
            {
                this.User = new Authentication(user);
            }
        }

        protected void SignIn(string name)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, name);
        }

        protected void SignOut(string name)
        {
            this.Request.Session.Clear();
        }
    }
}
