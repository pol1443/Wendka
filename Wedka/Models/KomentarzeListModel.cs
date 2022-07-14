using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedka.Models
{
    public class KomentarzeListModel
    {
        public PostModel post { get; set; }
        public ApplicationUser userPost { get; set; }
        public ICollection<KomentarzIuser>  komentarzeIuser { get; set; }
    }
}