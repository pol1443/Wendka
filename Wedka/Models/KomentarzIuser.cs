using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedka.Models
{
    public class KomentarzIuser
    {
        public KomentarzModel komentarz { get; set; }
        public ApplicationUser userKomentarz { get; set; }

        public KomentarzIuser()
        {

        }
        public KomentarzIuser(KomentarzIuser a)
        {
            this.komentarz = a.komentarz;
            this.userKomentarz = a.userKomentarz;
        }
    }
}