using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Domains;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class QuestionController : Controller
    {
        ApplicationDbContext db;

        public QuestionController()
        {
            db = new ApplicationDbContext();
          }

        public ActionResult Edit(int Id)
        {
            var quest =
            db.Questions
                .FirstOrDefault(q => q.Id == Id);
            return View(quest);
        }

        [HttpPost]
        public ActionResult Edit(Question qs)
        {
            var quest =
            db.Questions
                .FirstOrDefault(q => q.Id == qs.Id);
            quest.Text = qs.Text;
            db.SaveChanges();
            return View("Index");
        }


        // GET: Question
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(Question q)
        {
            return View(q);
        }

        /// <summary>
        /// Экшн для добавления нового вопроса в базу
        /// </summary>
        /// <param name="q">Вопрос</param>
        /// <param name="returnUrl">Url для возврата</param>
        /// <returns></returns>
        [HttpPost]
        public RedirectResult Add(Question q,
                                          string returnUrl)
        {
            db.Questions.Add(q);
            db.SaveChanges();
            return new RedirectResult(returnUrl);
        }

        public ActionResult PageShow()
        {
            return View(db.Questions);
        }
    }
}