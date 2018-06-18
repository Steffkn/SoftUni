namespace HTTPServer.Server.Infrastructure
{
    using HTTPServer.Server.Common;
    using HTTPServer.Server.Contracts;
    using HTTPServer.Server.Http;
    using HTTPServer.Server.Views;
    using Server.Enums;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public abstract class Controller
    {
        public IUserPrincipal User { get; set; }

        protected Controller(IHttpRequest req)
        {
            this.ViewData = new Dictionary<string, string>
            {
                ["authDisplay"] = "block"
            };

            this.PartialViews = new Dictionary<string, string>();

            if (req.Session.Contains(SessionStore.CurrentUserKey))
            {
                this.User = req.Session.Get<IUserPrincipal>(SessionStore.CurrentUserKey);
            }
        }

        protected IDictionary<string, string> PartialViews { get; private set; }

        protected IDictionary<string, string> ViewData { get; private set; }

        protected IHttpResponse FileViewResponse(string fileName)
        {
            var result = this.ProcessFileHtml(fileName);

            if (this.PartialViews.Any())
            {
                foreach (var value in this.PartialViews)
                {
                    var html = File.ReadAllText(string.Format(
                       ApplicationSettings.DefaultPath,
                       ApplicationSettings.ProjectName,
                       value.Value));
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", html);
                }
            }

            if (this.ViewData.Any())
            {
                foreach (var value in this.ViewData)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        private string ProcessFileHtml(string fileName)
        {
            const string ContentPlaceholder = "{{{content}}}";

            var layoutHtml = File.ReadAllText(
                    string.Format(
                        ApplicationSettings.DefaultPath,
                        ApplicationSettings.ProjectName,
                        ApplicationSettings.LayoutName));

            var fileHtml = File.ReadAllText(string.Format(
                    ApplicationSettings.DefaultPath,
                    ApplicationSettings.ProjectName,
                    fileName));
            var result = layoutHtml.Replace(ContentPlaceholder, fileHtml);

            return result;
        }
    }
}
