using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.DataContext;
using AspnetNote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspnetNote.Controllers
{
    public class NoteController : Controller
    {
        /// <summary>
        /// Note List
        /// </summary>
        /// <returns></returns>
        /// CRUD Funtion method
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //  No Login
                return RedirectToAction("Login", "Account");
            }
            using (var db = new AspnetNoteDbContext())
            {
                var list = db.Notes.ToList();
                return View(list);
            }
        }

        public IActionResult Add()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //  No Login
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(Note model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //  No Login
                return RedirectToAction("Login", "Account");
            }
            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());

            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    db.Notes.Add(model);

                    if(db.SaveChanges() > 0)
                    {
                        return Redirect("Index");
                    }
                }
                ModelState.AddModelError(string.Empty, "You don't save on borad!!");
            }
            return View(model);
        }

        public IActionResult Edit()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //  No Login
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public IActionResult Delete()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //  No Login
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}