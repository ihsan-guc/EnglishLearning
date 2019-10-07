using EnglishLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishLearning.DAL
{
    public class QuestionBO
    {
        public static Word GetWordExam(int id)
        {
            var lvl1MaxDate = DateTime.Now.Date.AddDays(-1);
            var lvl2MaxDate = DateTime.Now.Date.AddDays(-7);
            var lvl3MaxDate = DateTime.Now.Date.AddDays(-30);
            using (var db = new EnglishContext())
            {
                var model = db.Words.SingleOrDefault(p=>p.Id == id);
                var user = Convert.ToInt64(HttpContext.Current.Session["Id"]);
                if (model.Level > 1 || 
                    (model.Answers.All(p=>p.Date <=lvl1MaxDate)))
                {
                    return model;
                }
                else if (model.Level > 2 && model.Answers.All(p => p.Date <= lvl2MaxDate))
                {
                    return model;
                }
                else
                {
                    return model;
                }
            }
        }
        public static Word GetWordId()
        {
            var todayDate = DateTime.Now.Date;
            var nextDate = todayDate.AddDays(1);
            using (var db = new EnglishContext())
            {
                var x =Convert.ToInt32(HttpContext.Current.Session["Id"]);
                return db.Words.Where(p =>!p.Answers.Any(t => t.Date >= todayDate || t.Date < nextDate ) && !p.Answers.Any(t=>t.UserId == x)
                ).OrderBy(r => Guid.NewGuid()).FirstOrDefault();
            }
        }
        public static bool AnswerQuestion(int wordId, string answerText)
        {
            using (var db = new EnglishContext())
            {
                var word = db.Words.FirstOrDefault(p => p.Id == wordId);
                var isTrue = word.TranslateValue.ToUpper() == answerText.ToUpper();
                if (isTrue)
                    ++word.Level;
                var entity = new Answer
                {
                    Date = DateTime.Now,
                    IsTrue = isTrue,
                    WordId = wordId,
                    UserId = Convert.ToInt32(HttpContext.Current.Session["Id"])
                };
                db.Answers.Add(entity);
                db.SaveChanges();
                return isTrue;
            }
        }
        public static Word AddWord(Word word)
        {
            using (var db = new EnglishContext())
            {
                word.UserId = Convert.ToInt32(HttpContext.Current.Session["Id"]);
                word.Level += 1;
                word.Date = DateTime.Now;
                db.Words.Add(word);
                db.SaveChanges();
                return word;
            }
        }
    }
}