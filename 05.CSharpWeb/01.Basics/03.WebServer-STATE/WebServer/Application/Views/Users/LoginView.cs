namespace HttpWebServer.Application.Views.Users
{
    using HttpWebServer.Server.Common;
    using HttpWebServer.Server.Contracts;

    public class LoginView : IView
    {
        public string View()
        {
            var result = IOManager.ReadResourceFile("login.html");
            return result;
        }
    }
}
