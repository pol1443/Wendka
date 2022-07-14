using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedka.Models
{
    public class ArtykolModel
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
        public string zdjecieProfilowe { get; set; }
        public string zdjecia { get; set; }
        public DateTime kiedyNapisane { get; set; }
        public string komentarze { get; set; }
        public string temat { get; set; }
    }
}