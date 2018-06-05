namespace HTTPServer.ByTheCake.Views
{
    using HTTPServer.ByTheCake.Models;
    using HTTPServer.Server.Common;
    using HTTPServer.Server.Contracts;

    public class AddView : IView
    {
        private Cake cake;

        public AddView()
        {
        }

        public AddView(Cake cake)
        {
            this.cake = cake;
        }

        public string View()
        {
            var result = IOManager.ReadResourceFile("add.html");
            if (cake == null)
            {
                return result.Replace("{newCake}", "");
            }
            else
            {
                return result.Replace("{newCake}", $"<div>Name: {cake.Name} Price: {cake.Price}</div>");
            }
        }
    }
}
