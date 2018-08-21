using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.DataContext;
using AspnetNote.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspnetNote.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            //ID, password need
            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    //Linq query - method chaining
                    var user = db.Users
                        .FirstOrDefault(u => u.UserId.Equals(model.UserId) && 
                        u.UserPassword.Equals(model.UserPassword));
                    if(user == null)
                    {

                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                using(var db = new AspnetNoteDbContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges(); // Commit
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}