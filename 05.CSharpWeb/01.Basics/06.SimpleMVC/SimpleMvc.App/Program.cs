namespace SimpleMvc.App
{
    using SimpleMVC.Framework;
    using SimpleMVC.Framework.Routers;
    using WebServer;

    public class Program
    {
        public static void Main(string[] args)
        {
            var server = new WebServer(8000, new ControllerRouter());
            MvcEngine.Run(server);
        }
    }
}
