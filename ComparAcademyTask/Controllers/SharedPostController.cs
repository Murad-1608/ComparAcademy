using BusinessLayer.Managers;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ComparAcademyTask.Controllers
{
    public class SharedPostController : Controller
    {
        private ShareManager db_share;
        private UserManager db_user;
        public SharedPostController(ShareManager db_share, UserManager db_user)
        {
            this.db_share = db_share;
            this.db_user = db_user;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var values = db_share.GetWithPostAndUser(Convert.ToInt32(HttpContext.Session.GetString("ID")));
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var entity = db_share.GetById(id);
            db_share.Delete(entity);

            return RedirectToAction("Index");
        }

        public IActionResult Share(string email, int id)
        {

            var recipient = db_user.GetAll().FirstOrDefault(x => x.Email == email);
            if (recipient == null)
            {
                TempData["Exception"] = "Bu email-ə uyğun istifadəçi yoxdur.";
                TempData["ID"] = id;
            }
            else
            {
                Share entity = new Share()
                {
                    PostID = id,
                    SenderID = Convert.ToInt32(HttpContext.Session.GetString("ID")),
                    RecipientID = recipient.ID
                };

                db_share.Add(entity);
            }

            return RedirectToAction("Index", "MyPost");
        }

        public async Task<IActionResult> DownloadFile(string filePath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photos", filePath);
            var memory = new MemoryStream();

            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {

                    await stream.CopyToAsync(memory);
                }

            }
            catch (Exception)
            {
            }

            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);

            return File(memory, contentType, fileName);
        }
    }
}
