namespace WebServer.Http.Response
{
    using Http.Contracts;
    using Enums;
    using System;
    using global::WebServer.Exceptions;

    public class FileResponse : IHttpResponse
    {
        public byte[] FileData { get; }

        public HttpStatusCode StatusCode { get; }

        public IHttpHeaderCollection Headers => throw new System.NotImplementedException();

        public IHttpCookieCollection Cookies => throw new System.NotImplementedException();

        public FileResponse(HttpStatusCode statusCode, byte[] fileData)
        {
            this.ValidateStatusCode(statusCode);
            this.FileData = fileData;
            this.StatusCode = statusCode;

            this.Headers.Add(HttpHeader.ContentLength, this.FileData.Length.ToString());
            this.Headers.Add(HttpHeader.ContentDisposition, "attachment");
        }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            var statusCodeNumber = (int)statusCode;

            if (299 > statusCodeNumber && statusCodeNumber < 400)
            {
                throw new InvalidResponseException("File resposes need a status code above 300 and below 400.");
            }
        }
    }
}
