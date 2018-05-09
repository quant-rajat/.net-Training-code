using Autofac;
using Library.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        public IUserServices userDetails;
        // GET: Home
        public HomeController(IUserServices userDetails)
        {
            this.userDetails = userDetails;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}