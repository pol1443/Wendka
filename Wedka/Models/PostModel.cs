using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wedka.Models
{
    public class PostModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data dodania")]
        public DateTime kiedyNapisane { get; set; }
        [Required]
        [AllowHtml]
        public string post { get; set; }
        [Required]
        [Display(Name = "Kategoria")]
        public string kategoria { get; set; }
        public string zdjecie1 { get; set; }
        public string zdjecie2 { get; set; }
        public string zdjecie3 { get; set; }
        public string zdjecie4 { get; set; }
        public string iloscKom { get; set; }
        [Display(Name = "Temat")]
        public string temat { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<KomentarzModel> KomentarzModel { get; set; }

    }
}