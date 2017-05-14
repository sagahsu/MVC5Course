using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult ViewTest()
        {
            return View();
        }

        public ActionResult RazerTest()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5 };
            return PartialView(data);
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult unkonw()
        {
            return View();
        }

        [ShareViewBag(MyMessage= "ActionFilter.MyMessage")]
        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            throw new ArgumentException("Error Handled!!");
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }


}