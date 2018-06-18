namespace SimpleMVC.Framework.Routers
{
    using SimpleMVC.Framework.Attributes.Methods;
    using SimpleMVC.Framework.Controllers;
    using SimpleMVC.Framework.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Extensions;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    /// <summary>
    /// The main purpose of this class would be to transform the incoming request to a response. 
    /// </summary>
    public class ControllerRouter : IHandleable
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            IDictionary<string, string> getParams = request.UrlParameters;
            IDictionary<string, string> postParams = request.FormData;
            string requestMethod = request.Method.ToString().ToUpper();
            var urlTokens = request.Path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (urlTokens.Length != 2)
            {
                return new BadRequestResponse();
            }

            string controllerName = urlTokens[0].ToUpperFirstLetter();
            string actionName = urlTokens[1].ToUpperFirstLetter();

            Controller controller = this.GetController(controllerName);

            if (controller != null)
            {
                controller.Request = request;
                controller.InitializeController();
            }

            MethodInfo method = this.GetMethod(controller, actionName, requestMethod);

            if (method == null)
            {
                return new NotFoundResponse();
            }

            ParameterInfo[] parameters = method.GetParameters();

            object[] methodParams = this.AddParameters(parameters, getParams, postParams);

            try
            {
                IHttpResponse response = this.GetResponse(method, controller, methodParams);
                return response;
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResponse(ex);
            }
        }

        private IHttpResponse GetResponse(MethodInfo method, Controller controller, object[] methodParams)
        {
            object actionResult = method.Invoke(controller, methodParams);
            IHttpResponse response = null;

            if (actionResult is IViewable)
            {
                string content = ((IViewable)actionResult).Invoke();
                response = new ContentResponse(HttpStatusCode.Ok, content);
            }
            else if (actionResult is IRedirectable)
            {
                string redirectUrl = ((IRedirectable)actionResult).Invoke();
                response = new RedirectResponse(redirectUrl);
            }

            return response;
        }

        private object[] AddParameters(ParameterInfo[] parameters, IDictionary<string, string> getParams, IDictionary<string, string> postParams)
        {
            object[] methodParams = new object[parameters.Count()];

            for (int index = 0; index < parameters.Length; index++)
            {
                ParameterInfo parameter = parameters[index];
                if (parameter.ParameterType.IsPrimitive ||
                    parameter.ParameterType == typeof(string))
                {
                    methodParams[index] = this.ProcessPrimitiveParameters(getParams, parameter);
                }
                else
                {
                    methodParams[index] = ProcessComplexParameters(postParams, parameter);
                }
            }

            return methodParams;
        }

        private object ProcessPrimitiveParameters(IDictionary<string, string> getParams, ParameterInfo parameter)
        {
            object value = getParams[parameter.Name];
            return Convert.ChangeType(value, parameter.ParameterType);
        }

        private object ProcessComplexParameters(IDictionary<string, string> postParams, ParameterInfo parameter)
        {
            Type bindingModelType = parameter.ParameterType;
            object bindingModel = Activator.CreateInstance(bindingModelType);
            IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                property.SetValue(
                    bindingModel,
                    Convert.ChangeType(postParams[property.Name], property.PropertyType)
                    );
            }

            return Convert.ChangeType(bindingModel, bindingModelType); ;
        }

        // Returns the requested method from the controller or null if no such method is found.
        private MethodInfo GetMethod(Controller controller, string actionName, string requestMethod)
        {
            foreach (MethodInfo methodInfo in this.GetSiutableMethods(controller, actionName))
            {
                IEnumerable<Attribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(attribute => attribute is HttpMethodAttribute);

                if (!attributes.Any() && requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            // method not found
            return null;
        }

        // The GetSuitableMethods() method get all methods of the requested controller.
        private IEnumerable<MethodInfo> GetSiutableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(method => method.Name == actionName);
        }

        // The GetController() method creates an instance of the requested controller using the full path to the controller in the project.
        private Controller GetController(string controllerName)
        {
            var controllerFullyQualifiedname = string.Format(
                "{0}.{1}.{2}{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                controllerName,
                MvcContext.Get.ControllersSuffix
                );

            Type type = Type.GetType(controllerFullyQualifiedname);

            if (type == null)
            {
                return null;
            }

            var controller = (Controller)Activator.CreateInstance(type);
            return controller;
        }
    }
}
