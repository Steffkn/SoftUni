namespace SimpleMvc.App.Controllers
{
    using SimpleMVC.Framework.Controllers;
    using SimpleMVC.Framework.Interfaces;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
