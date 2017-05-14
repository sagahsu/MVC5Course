using MVC5Course.Models;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [HandleError(ExceptionType = typeof(DbEntityValidationException), View = "Error_DbEntityValidationException")]
    public abstract class BaseController :Controller//ad  abstract to avoid /Base/Debug workiing
    {
        protected FabricsEntities1 db = new FabricsEntities1();

        public ActionResult GetJson()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return Json(db.Product.Take(5),JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFile()
        {
            //return File(  Server.MapPath("~/App_Data/myBicycle.jpg"), "image/jpeg");
            return File(Server.MapPath("~/App_Data/myBicycle.jpg"), "image/jpeg", "NewMyBicycle.jpg");
        }

        public ActionResult SomeAction()
        {
            return PartialView("SuccessRedirect","/");
        }

        [LocalOnly]
        public ActionResult Debug()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("About");
            }
            else
            {
                return View("About");
            }
            //return Content("HELLO");
        }

        protected override void HandleUnknownAction(string actionName)
        {
            if (this.ControllerContext.HttpContext
            .Request.HttpMethod.ToUpper() == "GET")
            {
                this.View(actionName).ExecuteResult(this.ControllerContext);
            }
            else
            {
                base.HandleUnknownAction(actionName);
            }
        }
    }
}