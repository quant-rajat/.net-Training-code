using Library.Contracts.Repository;
using Library.Contracts.Services;
using Library.Models;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;
using static Library.Models.AccountViewModels;


namespace Library.Controllers
{
    [Authorize]
    public class AccountController :Controller
    {
       IUserServices userService;

        public AccountController(IUserServices UserService)
        {
            this.userService = UserService;
        }

        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(LoginViewModel credentials)
        {


            User userdetails = null;

            if (ModelState.IsValid)
            {
                userdetails = userService.AuthenticateUser(credentials.Username, credentials.Password);

                if (userdetails != null)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket("admin", false, 20);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                    HttpContext.Response.Cookies.Add(cookie);
                    Session["CurrentUser"] = userdetails; 

                   return RedirectToAction("index", "home");


                }
                else
                {
                    ModelState.AddModelError("login error", "invalid credentials");
                    return View(credentials);
                }
            }
            else
            {
               ModelState.AddModelError("login error", "invalid credentials");
                return View(credentials);
            }
        }
       
       


    }
}