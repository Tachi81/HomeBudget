using System.Web.Mvc;
using HomeBudget.DAL.Interfaces;

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
        
       
    }
}