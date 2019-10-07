using EnglishLearning.DAL;
using EnglishLearning.Models;
using System.Linq;
using System.Timers;
using System.Web.Mvc;

namespace EnglishLearning.Controllers
{
    public class LearningWordsController : Controller
    {
        EnglishContext db = new EnglishContext();
        public ActionResult Index(Word word)
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetWordToScreen(int id)
        {
            var word = QuestionBO.GetWordExam(id);
            if (word == null)
            {
                return View();
            }
            else
            {
                var model = db.Words.SingleOrDefault(p=>p.Id == id);
                return Json(model,JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Reply(Word word)
        {
            var isTrue = QuestionBO.AnswerQuestion(word.Id, word.TranslateValue);
            return Json(isTrue, JsonRequestBehavior.AllowGet);
        }
        public JsonResult WordToScreen()
        {
            var word = QuestionBO.GetWordId();
            if (word == null)
            {
                ViewBag.Message = "Word Done";
                return Json(word);
            }
            else
            {
                return Json(word.Id, JsonRequestBehavior.AllowGet);
            }
        }
    }
}