namespace HTTPServer.ByTheCake.Views.Users
{
    using HTTPServer.Server.Common;
    using Server.Contracts;

    public class HomeIndexView : IView
    {
        public string View()
        {
            var result = IOManager.ReadResourceFile("index.html");
            return result;
        }
    }
}
