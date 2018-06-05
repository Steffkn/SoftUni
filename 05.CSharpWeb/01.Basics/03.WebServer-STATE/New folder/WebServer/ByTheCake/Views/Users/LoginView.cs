namespace HTTPServer.ByTheCake.Views.Users
{
    using HTTPServer.Server.Common;
    using HTTPServer.Server.Contracts;

    public class LoginView : IView
    {
        public string View()
        {
            var result = IOManager.ReadResourceFile("login.html");
            return result;
        }
    }
}
