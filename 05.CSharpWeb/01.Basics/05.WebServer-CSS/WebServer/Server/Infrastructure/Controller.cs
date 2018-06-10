namespace HTTPServer.Server.Infrastructure
{
    using HTTPServer.Server.Common;
    using HTTPServer.Server.Views;
    using Server.Enums;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public abstract class Controller
    {
        protected Controller()
        {
            this.ViewData = new Dictionary<string, string>
            {
                ["authDisplay"] = "block"
            };
        }

        protected IDictionary<string, string> ViewData { get; private set; }

        protected IHttpResponse FileViewResponse(string fileName)
        {
            var result = this.ProcessFileHtml(fileName);

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
            var layoutHtml = File.ReadAllText(
                string.Format(
                    ApplicationSettings.DefaultPath, 
                    ApplicationSettings.ProjectName, 
                    ApplicationSettings.LayoutName));

            var fileHtml = File
                .ReadAllText(string.Format(ApplicationSettings.DefaultPath, ApplicationSettings.ProjectName, fileName));

            var result = layoutHtml.Replace(ApplicationSettings.ContentPlaceholder, fileHtml);

            return result;
        }
    }
}
