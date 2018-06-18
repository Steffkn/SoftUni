namespace SimpleMVC.Framework.Routers
{
    using System;
    using System.IO;
    using System.Linq;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ResourceRouter : IHandleable
    {

        public IHttpResponse Handle(IHttpRequest request)
        {
            string fileFullName = request.Path.Split("/").Last();
            string fileExtension = request.Path.Split(".").Last();
            IHttpResponse fileRespose = null;

            try
            {
                byte[] fileContent = this.ReadFileContent(fileFullName, fileExtension);
                fileRespose = new FileResponse(HttpStatusCode.Found, fileContent);
            }
            catch (Exception)
            {
                return new NotFoundResponse();
            }

            return fileRespose;
        }

        private byte[] ReadFileContent(string fileFullName, string fileExtension)
        {
            byte[] byteContent = File.ReadAllBytes(string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ResourcesFolder,
                fileExtension,
                fileFullName
                ));

            return byteContent;
        }
    }
}
