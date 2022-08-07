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

    public class StatystykiKategoriModel
    {
        public string nazwaKategori { get; set; }
        public int iloscPosty { get; set; }
        public int iloscOdpowiedzi { get; set; }
        public string ostatniTemat { get; set; }
        public string ostatniAutor { get; set; }
        public DateTime ostatniaData { get; set; }

        public StatystykiKategoriModel()
        {

        }
        public StatystykiKategoriModel(StatystykiKategoriModel a)
        {
            this.nazwaKategori = a.nazwaKategori;
            this.iloscPosty = a.iloscPosty;
            this.iloscOdpowiedzi = a.iloscOdpowiedzi;
            this.ostatniTemat = a.ostatniTemat;
            this.ostatniAutor = a.ostatniAutor;
            this.ostatniaData = a.ostatniaData;
        }

    }
}