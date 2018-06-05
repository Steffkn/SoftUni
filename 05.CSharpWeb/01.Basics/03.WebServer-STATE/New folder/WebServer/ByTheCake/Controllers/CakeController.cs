namespace HTTPServer.ByTheCake.Controllers
{
    using HTTPServer.ByTheCake.Models;
    using HTTPServer.ByTheCake.Views;
    using HTTPServer.Server.Common;
    using HTTPServer.Server.Enums;
    using HTTPServer.Server.Http.Contracts;
    using HTTPServer.Server.Http.Response;

    public class CakeController
    {
        public IHttpResponse AddGet()
        {
            return new ViewResponse(HttpStatusCode.Ok, new AddView());
        }

        public IHttpResponse AddPost(string cakeName, decimal cakePrice)
        {
            var newCake = new Cake(cakeName, cakePrice);
            IOManager.WriteToDatabase(newCake.ToString());
            return new ViewResponse(HttpStatusCode.Ok, new AddView(newCake));
        }
    }
}
