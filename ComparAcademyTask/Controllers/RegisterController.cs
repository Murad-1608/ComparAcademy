using BusinessLayer.Managers;
using BusinessLayer.Validations;
using DataAccessLayer.Security;
using EntityLayer.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ComparAcademyTask.Controllers
{
    public class RegisterController : Controller
    {

        private UserManager db;
        public RegisterController(UserManager db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(User user)
        {
            UserValidation uv = new UserValidation();

            ValidationResult result = uv.Validate(user);

            if (result.IsValid)
            {
                var email = db.GetAll().FirstOrDefault(x=>x.Email==user.Email);

                if (email==null)
                {                 
                    user.Password = Utils.PasswordHash(user.Password);

                    db.Add(user);
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.Exception = "Bu email mövcuddur";
                    return View();
                }
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

    }
}
