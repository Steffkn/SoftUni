namespace HttpWebServer.Server.HTTP
{
    using Contracts;
    using HttpWebServer.Server.Common;

    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;

        public HttpContext(IHttpRequest httpRequest)
        {
            CoreValidator.ThrowIfNull(httpRequest, nameof(httpRequest));

            this.request = httpRequest;
        }

        public IHttpRequest Request => this.request;
    }
}
