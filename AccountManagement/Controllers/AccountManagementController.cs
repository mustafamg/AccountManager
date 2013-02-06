using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using AccountManagement.Models;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;

namespace AccountManagement.Controllers
{
    public class AccountManagementController : Controller
    {
        //
        // GET: /AccountManagement/
        
        private readonly IRegisterRepository _repository;// = new RegisterRepository();
      
        public AccountManagementController(IRegisterRepository repo)
        {
            _repository = repo;
        }
        public ActionResult Index()
        {
            RegisterEntry entry = _repository.Get(System.Web.HttpContext.Current.User.Identity.Name);
            
            return View(entry);
        } 
        
        [Authorize]
        public ActionResult ViewData()
        {

            RegisterEntry entry = _repository.Get(System.Web.HttpContext.Current.User.Identity.Name);
            
            if (_repository.UpdateEntry(entry) == true)
            {
                Console.Write("Success... :D");
            }
            else
            {
                Console.Write("Faild... :(");
            }
            return View(entry);
        }
        [Authorize]
        public ActionResult Edit()
        {
            RegisterEntry entry = _repository.Get(System.Web.HttpContext.Current.User.Identity.Name);
            //if (entry == null)
            //{
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            //}

            return View(entry);
            //RegisterEntry entry = _repository.Get(email);
            //if (entry == null)
            //{
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            //}
            //return View(entry);
        }
        [Authorize][HttpPost]
        public ActionResult Edit(RegisterEntry entry)
        {
            _repository.UpdateEntry(entry);
            return RedirectToAction("viewData");
        }

       
      
    }
}
