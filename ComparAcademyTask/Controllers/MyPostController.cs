using BusinessLayer.Managers;
using BusinessLayer.Validations;
using EntityLayer.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace ComparAcademyTask.Controllers
{
    [Authorize]
    public class MyPostController : Controller
    {
        private PostManager db;

        public MyPostController(PostManager db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var id = HttpContext.Session.GetString("ID");

            var values = db.GetAll().Where(x => x.UserID == Convert.ToInt32(id)).ToList();

            return View(values);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {

            try
            {
                var entity = db.GetById(id);

                string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos/" + entity.Image);

                if (System.IO.File.Exists(FolderPath))
                {
                    System.IO.File.Delete(FolderPath);
                }

                db.Delete(entity);
            }

            catch (Exception)
            {
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Post entity, IFormFile Photo)
        {
            try
            {
                PostValidation uv = new PostValidation();

                ValidationResult result = uv.Validate(entity);


                if (!result.IsValid)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                if (Photo==null)
                {
                    ViewBag.Exception = "Xahiş olunur fayl seçin";
                    return View();
                }
                else
                {              
                    
                    var extension = Path.GetExtension(Photo.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos/" + newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    Photo.CopyTo(stream);
                    entity.Image = newImageName;

                    entity.UserID = Convert.ToInt32(HttpContext.Session.GetString("ID"));

                    db.Add(entity);
                    return RedirectToAction("Index");
                }
            }

            catch (Exception)
            {
            }
            return View();

        }
    }
}
