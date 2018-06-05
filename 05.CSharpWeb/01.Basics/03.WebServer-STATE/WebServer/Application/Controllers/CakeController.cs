namespace HttpWebServer.Application.Controllers
{
    using HttpWebServer.Application.Models;
    using HttpWebServer.Application.Views;
    using HttpWebServer.Enums;
    using HttpWebServer.Server.Common;
    using HttpWebServer.Server.HTTP.Contracts;
    using HttpWebServer.Server.HTTP.Response;

    public class CakeController
    {
        public IHttpResponse AddGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new AddView());
        }

        public IHttpResponse AddPost(string cakeName, decimal cakePrice)
        {
            var newCake = new Cake(cakeName, cakePrice);
            IOManager.WriteToDatabase(newCake.ToString());
            return new ViewResponse(HttpStatusCode.OK, new AddView(newCake));
        }
    }
}
