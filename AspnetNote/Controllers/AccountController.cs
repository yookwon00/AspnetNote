using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.DataContext;
using AspnetNote.Models;
using AspnetNote.ViewModel;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Login(LoginViewModel model)
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
                    if (user != null)
                    {
                        // login success
                        //HttpContext.Session.SetInt32(key, value);
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);
                        return RedirectToAction("LoginSuccess", "Home"); // go to loginSuccess page
                    }
                }
                //login fail
                ModelState.AddModelError(string.Empty, "Wrong ID or Wrong Password");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");
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