using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedka.Models
{
    public class PostyIndexModel
    {

        public PostModel post { get; set; }
        public ApplicationUser userPost { get; set; }
        public KomentarzModel komentarz { get; set; }
        public ApplicationUser userKomentarz { get; set; }
        public PostyIndexModel()
        {

        }
        public PostyIndexModel(PostyIndexModel a)
        {
            this.post = a.post;
            this.userPost = a.userPost;
            this.komentarz = a.komentarz;
            this.userKomentarz = a.userKomentarz;
        }
    }
}