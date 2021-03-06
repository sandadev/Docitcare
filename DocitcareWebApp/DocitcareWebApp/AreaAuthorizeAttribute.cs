﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocitcareWebApp
{
    public class AreaAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string area;
        public AreaAuthorizeAttribute(string area)
        {
            this.area = area;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string loginUrl = "";

            if (area == "Admin")
            {
                loginUrl = "~/Admin/Account/Login";
            }
            else if (area == "SuperAdmin")
            {
                loginUrl = "~/SuperAdmin/Account/Login";
            }
           
            filterContext.Result = new RedirectResult(loginUrl + "?returnUrl=" + filterContext.HttpContext.Request.Url.PathAndQuery);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session == null || httpContext.Session["entity"] ==null || httpContext.Session["staffid"]==null)
                return false;

            return base.AuthorizeCore(httpContext);
        }


    }
}