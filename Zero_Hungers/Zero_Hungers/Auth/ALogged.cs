using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zero_Hungers.Auth
{
    public class ALogged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["AdminID"] != null)
            {
                return true;
            }

            else
            {
                httpContext.Response.Redirect("~/Admin/Login");
                return false;
            }
        }
    }
}