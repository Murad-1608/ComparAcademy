using BusinessLayer.Managers;
using ComparAcademyTask.Models;
using DataAccessLayer.Security;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace ComparAcademyTask.Controllers
{
    public class LoginController : Controller
    {
        private UserManager db;
        public LoginController(UserManager db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User entity)
        {

            var user = db.GetAll().FirstOrDefault(x => x.Email == entity.Email && x.Password == Utils.PasswordHash(entity.Password));

            if (user != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim("Email",user.Email),
                    new Claim("Name",user.Name),
                    new Claim("ID",user.ID.ToString())
                };
                 
                ClaimsIdentity indentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(indentity);
                await HttpContext.SignInAsync(principal);

                HttpContext.Session.SetString("ID", user.ID.ToString());
                HttpContext.Session.SetString("Name", user.Name.ToString());

                UserModel.Name = HttpContext.Session.GetString("Name");






                return RedirectToAction("Index", "MyPost");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");


        }

        public IActionResult test()
        {

            return View();
        }
    }
}
