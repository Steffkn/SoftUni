namespace HTTPServer.ByTheCake.Views.Home
{
    using HTTPServer.ByTheCake.Models;
    using HTTPServer.Server.Common;
    using HTTPServer.Server.Contracts;

    public class HomeSearchView : IView
    {
        private Cake cake;

        public HomeSearchView(Cake cake)
        {
            this.cake = cake;
        }

        public string View()
        {
            var result = IOManager.ReadResourceFile("search.html");
            if (cake == null)
            {
                return result.Replace("{searchResult}", "");
            }
            else
            {
                return result.Replace("{searchResult}", $"<div>Name: {cake.Name} Price: ${cake.Price}</div>");
            }
        }
    }
}
