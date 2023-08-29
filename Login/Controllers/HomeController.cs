using Login.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         
        Context _context=new Context();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult urunListesi()
        {
            List<Product> urunler = _context.Products.ToList() ;

            return View(urunler);
        }

        public IActionResult Success()
        {
             SuccessViewModel model = new SuccessViewModel();

            model.Message = "kaydedildi";
            
            return View(model);
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Privacy","Home");
            }

            _context.UserModels.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Success", "Home");

        }
        public IActionResult LogIn (User model)
        {
            var loginEntities = _context.UserModels.ToList();
            var user = loginEntities.FirstOrDefault(user => user.UserName.Trim() == model.UserName.Trim() && user.Password == model.Password);
            if(user == null)
            {
                
            }

            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,model.UserName)
                };
            var claimIdentity = new ClaimsIdentity(claims, "cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);

            HttpContext.SignInAsync(claimPrincipal);




            return Ok();
        }
        
        public IActionResult UyeOl()
        {

            return View();
        }
        [HttpPost]
        public IActionResult UyeOl(User userInfo)
        {
            if (userInfo != null)
            {
                _context.UserModels.Add(userInfo);
                _context.SaveChanges();
            }
            return Ok();
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