using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HollyDaysV2.Controllers;
using HollyDaysV2.Models;


namespace HollyDaysV2.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (Empleados)HttpContext.Current.Session["User"];

            if (oUser == null) {
                if (filterContext.Controller is AccesoController == false) {
                    HttpContext.Current.Response.Redirect("~/Acceso/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccesoController == true)
                {
                    HttpContext.Current.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}