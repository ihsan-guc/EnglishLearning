using EnglishLearning.DAL;
using EnglishLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EnglishLearning.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        // GET: Security
        EnglishContext db = new EnglishContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users users)
        {
            var account = db.Users.SingleOrDefault( p=>p.Password == users.Password && p.User == users.User);
            if (account.User == users.User && account.Password == users.Password)
            {
                Session["Id"] = account.Id;
                FormsAuthentication.SetAuthCookie(account.User, false);
                return RedirectToAction("Index", "AddWord");
            }
            else
            {
                ViewBag.Message = "Invalid Password";
                return View();
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Users users)
        {
            if (users.Password == null || users.User == null || users.ConfirmPassword == null)
            {
                ViewBag.Message = "Incorrect User And Password";
                return View();
            }
            if (users.Password == users.ConfirmPassword)
            {
                db.Users.Add(users);
                users.Role = "B";
                db.SaveChanges();
                return View("Login");
            }
            else
            {
                ViewBag.Message = "Incorrect User And Password";
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}