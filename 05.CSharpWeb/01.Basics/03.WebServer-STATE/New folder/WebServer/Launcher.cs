namespace HTTPServer
{
    using HTTPServer.ByTheCake;
    using HTTPServer.Server;
    using HTTPServer.Server.Routing;

    public class Launcher
    {
        private static int port = 8230;

        static void Main(string[] args)
        {
            Run(args);
        }

        static void Run(string[] args)
        {
            var appRouteConfig = new AppRouteConfig();
            var app = new ByTheCakeApplication();
            app.Start(appRouteConfig);
            var server = new WebServer(port, appRouteConfig);
            server.Run();
        }
    }
}
