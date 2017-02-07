using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Domains
{
    [Table("QuestionAnswer")]
    public class QuestionSectionRelation
    {
        public int QuestId { get; set; }
        [ForeignKey("QuestId")]
        public Question Question { get; set; }

        public int SectionId { get; set; }
        [ForeignKey("SectionId")]
        public Section Section { get; set; }
    }
}