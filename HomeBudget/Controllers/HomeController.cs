using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeBudget.DAL.Interfaces;
using HomeBudget.Models;

namespace HomeBudget.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IBankAccountRepository _bankAccount;
        
        public  HomeController(IBankAccountRepository bankAccount)
        {
            _bankAccount = bankAccount;
        }
        public ActionResult Index()
        {
            
            return View("Index", _bankAccount.GetWhere(x => x.Id > 0));
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}