namespace HTTPServer.Server.Http.Response
{
    using System.IO;
    using HTTPServer.Server.Common;
    using HTTPServer.Server.Enums;

    public class FileResponse : HttpResponse
    {
        public FileResponse(string path)
        {
            var filePath = string.Format("{0}\\{1}\\{2}", ApplicationSettings.CurrentDirrectory, ApplicationSettings.ProjectName, path);
            using (var streamReader = new StreamReader(filePath))
            {
                this.StatusCode = HttpStatusCode.Ok;
                string fileContent = streamReader.ReadToEnd();
                this.Content = fileContent;

                var headerType = "text/plain";
                if (filePath.EndsWith(".css"))
                {
                    headerType = "text/css";
                }

                this.Headers.Add(HttpHeader.ContentType, headerType);
            }
        }

        public string Content { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}{this.Content}";
        }
    }
}
