namespace SimpleMvc.App.Views.Home
{
    using SimpleMVC.Framework.Interfaces;

    public class Index : IRenderable
    {
        public string Render()
        {
            return "<h1>Hello there</h1>";
        }
    }
}
