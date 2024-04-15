using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserLogin.Models;
using Microsoft.AspNetCore.Http;

namespace UserLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly DemoDbcontext context;

        public HomeController(DemoDbcontext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("Usersession") != null)
            {
                HttpContext.Session.Remove("Usersession");
                return RedirectToAction("Login");   
            }
            return View();
        }
        [HttpPost]
        
           public IActionResult Login(TblUser user)
        {
            var User = context.TblUsers.Where(x => x.EmailId == user.EmailId && x.Password == user.Password).FirstOrDefault();
            if (User != null)
            {
                HttpContext.Session.SetString("Usersession", User.UserName);

                return RedirectToAction("Dashbord");
            }
            else
            {
                ViewBag.Message = "UserName or password is Invalid... ";
            }
            return View();
        }
        public IActionResult Dashbord()
        {
            if(HttpContext.Session.GetString("Usersession") != null)
            {
                ViewBag.mysession = HttpContext.Session.GetString("Usersession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
