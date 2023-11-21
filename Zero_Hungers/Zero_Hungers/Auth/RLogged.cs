using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zero_Hungers.Auth
{
    public class RLogged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["RestaurantID"] != null)
            {
                return true;
            }

            else
            {
                httpContext.Response.Redirect("~/Restaurant/Login");
                return false;
            }
        }
    }
}