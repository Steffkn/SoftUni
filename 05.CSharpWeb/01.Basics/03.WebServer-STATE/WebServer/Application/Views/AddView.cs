namespace HttpWebServer.Application.Views
{
    using HttpWebServer.Server;
    using HttpWebServer.Server.Common;
    using HttpWebServer.Server.Contracts;

    public class AddView : IView
    {
        private Model model;

        public AddView()
        {
        }

        public AddView(Model model)
        {
            this.model = model;
        }

        public string View()
        {
            var result = IOManager.ReadResourceFile("add.html");
            if (model == null)
            {
                return result.Replace("{newCake}", "");
            }
            else
            {
                return result.Replace("{newCake}", $"<div>Name: {model["cakeName"]} Price: {model["cakePrice"]}</div>");
            }
        }
    }
}
