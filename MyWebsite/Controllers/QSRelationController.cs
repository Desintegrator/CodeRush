using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.Domains;

namespace MyWebsite.Controllers
{
    public class QSRelationController : Controller
    {
        ApplicationDbContext db;

        public QSRelationController()
        {
            db = new ApplicationDbContext();
        }

        // GET: QARelation
        public ActionResult BindQS(QSModel qa)
        {
            qa = new QSModel();

            var quests = db.Questions.ToList();
            var alredyQuestBind = db.QuestionSection.Select(x => x.Question).ToList();
            // выкинем уже связанные вопросы
            quests = quests.Except(alredyQuestBind).ToList();
            
            qa.Sects = db.Section
                .Select(a => new SelectListItem() { Text = a.Title, Value=a.Id.ToString() }).ToList();

            
            qa.Quests = quests
                .Select(a => new SelectListItem() { Text = a.Text, Value = a.Id.ToString() }).ToList();


            return View(qa);
        }

        [HttpPost]
        public RedirectResult BindQS(QSModel qa, string returnUrl)
        {
            int idQ = qa.QuestIds[0];
            int idA = qa.SectIds[0];

            var q = db.Questions.Find(idQ);
            var a = db.Section.Find(idA);
         
            var rel = new QuestionSectionRelation();
            rel.Section = a;
            rel.Question = q;
            db.QuestionSection.Add(rel);
            db.SaveChanges();

            return new RedirectResult(returnUrl);
        }


        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ShowRelations()
        {
            var result = from qa in db.QuestionSection
                         join q in db.Questions              
                         on qa.QuestId equals q.Id           
                         join a in db.Section                
                         on qa.SectionId equals a.Id          
                         select new QuestionSectionTextModel()
                         {
                             SectionText = a.Title,
                             QuestionText = q.Text
                         };
                         

             return View(result);
        }
    }
}