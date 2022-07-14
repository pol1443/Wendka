using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wedka.Models
{
    public class KomentarzModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int PostId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime kiedyNapisane { get; set; }
        [Required]
        [AllowHtml]
        public string komentarze { get; set; }
        public string zdjecie1 { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual PostModel PostModel { get; set; }

    }
}