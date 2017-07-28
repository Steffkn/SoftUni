﻿namespace _08.WebSumator.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calculate(int num1, int num2)
        {
            this.ViewBag.num1 = num1;
            this.ViewBag.num2 = num2;
            this.ViewBag.sum = num1 + num2;
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}