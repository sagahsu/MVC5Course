using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ShareViewBagAttribute : ActionFilterAttribute
    {
        public string MyMessage { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "Your application description page.(ActionFilterAttribute)";
        }
    }
}