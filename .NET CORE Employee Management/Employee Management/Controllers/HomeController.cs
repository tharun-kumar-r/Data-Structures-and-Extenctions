using Employee_Management.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Employee_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _dbcontext;
        public HomeController(ILogger<HomeController> logger, DBContext context)
        {

            _logger = logger;
            _dbcontext = context;
        }

        [Microsoft.AspNetCore.Mvc.Route("/home")]
        public IActionResult Index()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            if (userEmail == null)
            {
                return Redirect("/");
            }
            else
            {
                return View(_dbcontext.employees.ToList());
            }

         
        }

        [Microsoft.AspNetCore.Mvc.Route("/")]
        [HttpGet]
        public IActionResult Login()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            if (userEmail != null)
            {
                return Redirect("/home");
            }
            else
            {
                return View();
            }
          
        }

        [Microsoft.AspNetCore.Mvc.Route("/")]
        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                bool isValidUser = _dbcontext.logins.Any(x => x.email == model.email && x.password == model.password);

                if (isValidUser)
                {
                    HttpContext.Session.SetString("UserEmail", model.email);
                    return Redirect("/home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email or password.");
                }
            }
          
       
     
        return View(model);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("/register")]
        public IActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {

                _dbcontext.logins.Add(new Login{email = register.Email, password = register.Password });
                _dbcontext.SaveChanges();
                return Redirect("/");
            }
            return View();
        }


        public IActionResult EmailCheck(string email)
        {
        
            var emailExists = _dbcontext.logins.Any(u => u.email == email);

            if (emailExists)
            {
                return Json(false); 
            }

            return Json(true);
           
        }

        [Microsoft.AspNetCore.Mvc.Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
