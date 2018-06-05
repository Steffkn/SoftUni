namespace HttpWebServer.Server.HTTP.Response
{
    using HttpWebServer.Enums;
    using HttpWebServer.Server.Common;

    public class NotFoundResponse : ViewResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound, new NotFoundView())
        {
        }
    }
}
