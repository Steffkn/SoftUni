namespace HTTPServer.ByTheCake.Views.Home
{
    using HTTPServer.Server.Common;
    using HTTPServer.Server.Contracts;

    public class HomeAboutView : IView
    {
        public HomeAboutView()
        {
        }

        public string View()
        {
            var result = IOManager.ReadResourceFile("about.html");
            return result;
        }
    }
}
