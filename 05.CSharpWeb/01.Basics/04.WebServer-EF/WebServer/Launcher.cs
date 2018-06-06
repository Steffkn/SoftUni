namespace HTTPServer
{
    using HTTPServer.ByTheCakeApplication;
    using HTTPServer.Server;
    using HTTPServer.Server.Routing;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            Run(args);
        }

        static void Run(string[] args)
        {
            var application = new ByTheCakeApp();
            var appRouteConfig = new AppRouteConfig();
            application.Configure(appRouteConfig);

            var server = new WebServer(8000, appRouteConfig);

            server.Run();
        }
    }
}
