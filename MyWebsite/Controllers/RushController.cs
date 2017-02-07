using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.Domains;


namespace MyWebsite.Controllers
{
    public class RushController : Controller
    {
        ApplicationDbContext db;

        public RushController()
        {
            db = new ApplicationDbContext();
        }


        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NextQuestion()
        {
            // берем вопрос
            int n = 0;
            var qaIds =
            db.QuestionSection.Select(x =>
            new
            {
                QID = x.QuestId,
                AID = x.SectionId
            }).ToList();
            var item = qaIds[n];
            int key = item.QID;
            var q = db.Questions.Find(key);
            //========================================
            var answers = db.Section.ToList();
            var a = answers.FirstOrDefault(x => x.Id == item.AID);
            //========================================
        
            return View();
        }
    }
}