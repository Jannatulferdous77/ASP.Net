using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zero_Hungers.Auth
{
    public class ELogged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["EmployeeID"] != null)
            {
                return true;
            }

            else
            {
                httpContext.Response.Redirect("~/Employee/Login");
                return false;
            }
        }
    }
}