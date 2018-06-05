namespace HttpWebServer.Application.Views
{
    using HttpWebServer.Server;
    using HttpWebServer.Server.Common;
    using HttpWebServer.Server.Contracts;

    public class HomeSearchView : IView
    {
        private Model model;

        public HomeSearchView(Model model)
        {
            this.model = model;
        }

        public string View()
        {
            var result = IOManager.ReadResourceFile("search.html");
            if (model == null)
            {
                return result.Replace("{searchResult}", "");
            }
            else
            {
                return result.Replace("{searchResult}", $"<div>Name: {model["cakeName"]} Price: ${model["cakePrice"]}</div>");
            }
        }
    }
}
