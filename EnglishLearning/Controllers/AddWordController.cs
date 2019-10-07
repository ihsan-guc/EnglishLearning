using EnglishLearning.DAL;
using EnglishLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishLearning.Controllers
{
    public class AddWordController : Controller
    {
        EnglishContext db = new EnglishContext();
        [Authorize]
        public ActionResult Index()
        {
            var x = Convert.ToInt32(HttpContext.Session["Id"]);
            var model = db.Words.Where(p=>p.UserId == x).OrderBy(p=>p.Id).ToList();
            return View(model);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Word word)
        {
            if (word != null)
            {
                var words = QuestionBO.AddWord(word);
                return RedirectToAction("Index", "AddWord");
            }
            else
            {
                ViewBag.Mesaj = "Boş Alanları Doldurunuz";
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var model = db.Words.FirstOrDefault(p => p.Id == id);
            return View(model);
        }
        public ActionResult Deleteconfirmation(int id)
        {
            var model = db.Words.SingleOrDefault(p => p.Id == id);
            db.Words.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index", "AddWord");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = db.Words.SingleOrDefault(p => p.Id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Word word)
        {
            var model = db.Words.SingleOrDefault(p => p.Id == word.Id);
            model.Value = word.Value;
            model.Type = word.Type;
            model.TranslateValue = word.TranslateValue;
            db.SaveChanges();
            return RedirectToAction("Index", "AddWord");
        }
    }
}