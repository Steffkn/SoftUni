namespace HttpWebServer.Server.HTTP.Response
{
    using Enums;
    using Server.Contracts;

    public class ViewResponse : HttpResponse
    {
        public ViewResponse(HttpStatusCode httpStatusCode, IView view)
            : base(httpStatusCode, view)
        {
        }
    }
}
