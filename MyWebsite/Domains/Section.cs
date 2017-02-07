using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Domains
{
    [Table("Section")]
    public class Section
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}