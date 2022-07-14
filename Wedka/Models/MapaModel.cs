using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wedka.Models
{
    public class MapaModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        [Display(Name = "Tytuł:")]
        public string tytul { get; set; }
        [Required]
        [Display(Name = "Opis:")]
        public string opis { get; set; }
        [Required]
        public string lat { get; set; }
        [Required]
        public string lng { get; set; }

    }
}