using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class LocalOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new RedirectResult("/");//給filterContext.Result,就會跳過不執行ACTION
            }
        }
    }
}