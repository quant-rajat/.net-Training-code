using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Library.Attributes
{
    public class LibraryAuthorizeAttribute:AuthorizeAttribute
    {
        public bool Authorize { get; private set; }
        private readonly string[] allowedRoles;
       
        public LibraryAuthorizeAttribute(params string[] roles)
        {
            Authorize = false;
            allowedRoles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            
             //Authorize = false;
            User currentUser = (User)httpContext.Session["CurrentUser"];
            if (currentUser == null)
            {
                return false;
            }
            if (allowedRoles == null)
            {
                return true;
            }
            foreach (var role in allowedRoles)
            {
                if (currentUser.Roles.IndexOf(role) >= 0)
                {
                    Authorize = true;
                    break;
                }

            }
            return Authorize;
        }
        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    filterContext.Result = new HttpUnauthorizedResult();
        //}
    }
}