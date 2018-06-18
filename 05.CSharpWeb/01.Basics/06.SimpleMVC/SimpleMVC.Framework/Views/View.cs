namespace SimpleMVC.Framework.Views
{
    using SimpleMVC.Framework.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class View : IRenderable
    {
        public const string BaseLayoutFileName = "Layout";
        public const string ContentPlaceholder = "{{{Content}}}";
        public const string HtmlExtension = ".html";
        // TODO: fix this. spread it around stir and drink it all up
        public const string LocalErrorPath = "\\SimpleMvc.Framework\\Errors\\Error.html";

        private readonly string templateFullyQualifiedName;
        private readonly IDictionary<string, string> viewData;

        public View(string templateFullyQualifiedName, IDictionary<string, string> viewData)
        {
            this.templateFullyQualifiedName = templateFullyQualifiedName;
            this.viewData = viewData;
        }

        public string Render()
        {
            string fullHtml = this.ReadFile();
            if (this.viewData.Any())
            {
                foreach (var parameter in this.viewData)
                {
                    fullHtml = fullHtml.Replace($"{{{{{{{parameter.Key}}}}}}}", parameter.Value);
                }
            }

            return fullHtml;
        }

        private string ReadFile()
        {
            string layoutHtml = this.RenderLayoutHtml();

            string templateFullyQualifiedNameWithExtension = this.templateFullyQualifiedName + HtmlExtension;

            if (!File.Exists(templateFullyQualifiedNameWithExtension))
            {
                string errorPath = this.GetErrorPath();
                string errorHtml = File.ReadAllText(errorPath);
                this.viewData.Add("error", "Requested view does not exist!");
                return errorHtml;
            }

            string htmlResult = File.ReadAllText(templateFullyQualifiedNameWithExtension);
            htmlResult = htmlResult.Replace(ContentPlaceholder, htmlResult);

            return htmlResult;
        }

        private string GetErrorPath()
        {
            string appDirectoryPath = Directory.GetCurrentDirectory();
            DirectoryInfo parentDirecotry = Directory.GetParent(appDirectoryPath);
            string parentDirectoryPath = parentDirecotry.FullName;
            string errorPagePath = parentDirectoryPath + LocalErrorPath;

            return LocalErrorPath;
        }

        private string RenderLayoutHtml()
        {
            string layoutHtmlQualifiedName = string.Format(
                "{0}\\{1}{2}",
                MvcContext.Get.ViewsFolder,
                BaseLayoutFileName,
                HtmlExtension);

            if (!File.Exists(layoutHtmlQualifiedName))
            {
                string errorPath = this.GetErrorPath();
                string errorHtml = File.ReadAllText(errorPath);
                this.viewData.Add("error", "Layout view does not exist!");
                return errorHtml;
            }

            string layoutHtmlFileContent = File.ReadAllText(layoutHtmlQualifiedName);

            return layoutHtmlFileContent;
        }
    }
}
