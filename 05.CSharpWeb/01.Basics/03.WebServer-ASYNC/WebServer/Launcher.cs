namespace HttpWebServer
{
    using HttpWebServer.Application;
    using HttpWebServer.Server;
    using HttpWebServer.Server.Contracts;
    using HttpWebServer.Server.Routing;
    using HttpWebServer.Server.Routing.Contracts;

    public class Launcher : IRunnable
    {
        private WebServer webServer;

        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            IApplication app = new MainApplication();
            IAppRouteConfig appRouteConfig = new AppRouteConfig();
            app.Start(appRouteConfig);

            this.webServer = new WebServer(8230, appRouteConfig);
            this.webServer.Run();
        }
    }
}
