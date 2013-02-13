using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountManagement.Domain.Model;
using WebMatrix.WebData;

namespace AccountManagement.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Register(Account account)
        {

            WebSecurity.CreateUserAndAccount(account.Email, account.Password);
            
            WebSecurity.Login(account.Email, account.Password);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
