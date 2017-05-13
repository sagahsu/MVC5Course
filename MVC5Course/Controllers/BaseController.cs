using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public abstract class BaseController :Controller//ad  abstract to avoid /Base/Debug workiing
    {
        protected FabricsEntities1 db = new FabricsEntities1();

        public ActionResult Debug()
        {
            return Content("HELLO");
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