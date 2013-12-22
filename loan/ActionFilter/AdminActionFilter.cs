using System;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace loan.ActionFilter
{
    public class AdminActionFilter : Controller
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
        public class NoRedirect : Attribute
        {
            public NoRedirect() { }
        }




        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            object[] actionFilter = filterContext.ActionDescriptor.GetCustomAttributes(typeof(NoRedirect), false);
            object[] controllerFilter = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(NoRedirect), false);
            if (controllerFilter.Length == 1 || actionFilter.Length == 1)
            {
                return;
            }


            //当controller里面含有admin并且cookies["userName"]为空时，转到登陆页
            if (filterContext.HttpContext.Request.Cookies["userName"] == null)
            {
                filterContext.Result = RedirectToAction("login", "admin");//Account/LogOn


            }

        }
    }
}