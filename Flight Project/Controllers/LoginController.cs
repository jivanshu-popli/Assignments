using flightproject2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace flightproject2.Controllers{
    public class LoginController : Controller{
        private readonly Ace52024Context ls;
        private readonly ISession session;

        public LoginController(Ace52024Context _ls, IHttpContextAccessor httpContextAccessor)
        {
            ls = _ls;
            session = httpContextAccessor.HttpContext.Session;
        }

        public IActionResult Register(){
            return View();
        }

        [HttpPost]
        public IActionResult Register(CustomersJivanshu j){
            ls.CustomersJivanshus.Add(j);
            ls.SaveChanges();
            return RedirectToAction("Login");
        }
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Login(CustomersJivanshu j){
            
            var result = (from i in ls.CustomersJivanshus
                            where i.EmailAddress==j.EmailAddress && 
                            i.Password==j.Password
                            select i).SingleOrDefault();
            if(result != null){
                HttpContext.Session.SetString("email", result.EmailAddress);
                int customerId = result.CustomerId;
                HttpContext.Session.SetInt32("Customerid", customerId);
                if(result.EmailAddress == "admin@jivanshuskyport.com"){
                    return RedirectToAction("Home", "Admin");
                }
                return RedirectToAction("Search", "Book");
            }
            else{
                return View();
            }
        }

        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}