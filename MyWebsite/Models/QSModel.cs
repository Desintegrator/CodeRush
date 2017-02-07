using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebsite.Domains;
using System.Web.Mvc;

namespace MyWebsite.Models
{
    public class QSModel
    {
        public List<int> QuestIds { get; set; }
        public List<SelectListItem> Quests { get; set; }

        public List<int> SectIds { get; set; }
        public List<SelectListItem> Sects { get; set; }
    }
}