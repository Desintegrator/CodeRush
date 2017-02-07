using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Domains;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class SectionController : Controller
    {
        ApplicationDbContext db;

        public SectionController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            // тут 3 ссылки
            // pageShow
            // Add
            // Edit
            return View();
        }

        public ActionResult Add(Section a)
        {
            a = new Section();
            return View(a);
        }

        [HttpPost]
        public RedirectResult Add(Section a, string returnUrl)
        {
            db.Section.Add(a);
            db.SaveChanges();
            return new RedirectResult (returnUrl);
        }

        public ActionResult Edit(int Id)
        {
            var answ =
              db.Section
                  .FirstOrDefault(q => q.Id == Id);
            return View(answ);
        }

        [HttpPost]
        public ActionResult Edit(Section a)
        {
            var answ =
           db.Section
               .FirstOrDefault(q => q.Id == a.Id);
            answ.Title = a.Title;
            db.SaveChanges();
            return View("Index");
        }

        public ActionResult PageShow()
        {
            var answers = db.Section;
            return View(answers);
        }
    }
}