using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Wedka.Models;

namespace Wedka.Controllers
{
    public class ForumController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Forum
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string tekst)
        {
            if (tekst == "")
            {
                return View();
            }
            List<PostModel> postyWszystkie = context.Post.ToList();
            List<string> postyTematy = new List<string>();
            List<string> postyTematyPom = new List<string>();
            List<string> tematyZnalezione = new List<string>();
            foreach (PostModel post in postyWszystkie)
            {
                postyTematy.Add(post.temat);
                postyTematyPom.Add(post.temat);
            }

            foreach(string temat in postyTematyPom)
            {
                if (temat == tekst)
                {
                    tematyZnalezione.Add(temat);
                    postyTematy.Remove(temat);
                }
            }
            postyTematyPom = postyTematy;

            foreach (string temat in postyTematyPom)
            {
                if (temat.Contains(tekst))
                {
                    tematyZnalezione.Add(temat);
                }
            }

            TempData["tematy"] = tematyZnalezione;
            return RedirectToAction("Posty");
        }


        [HttpGet]
        public ActionResult Posty(string id)
        {

            List<PostModel> post = context.Post.ToList();
            List<PostyIndexModel> postKomList = new List<PostyIndexModel>();
            List<KomentarzModel> komentarzModels = context.Komentarz.ToList();
            List<KomentarzModel> komentarzModels2 = new List<KomentarzModel>();
            PostyIndexModel postIndexM = new PostyIndexModel();
            List<string> tematy = new List<string>();
            tematy = (List<string>)TempData["tematy"];

            if (id == null && tematy != null)
            {
                foreach (var i in post)
                {
                    foreach(string temat in tematy)
                    {
                        if (i.temat == temat)
                        {
                            postIndexM.post = i;
                            postIndexM.userPost = UserManager.FindById(i.UserId);
                            foreach (var j in komentarzModels)
                            {
                                if (j.PostId == i.Id)
                                {
                                    komentarzModels2.Add(j);
                                }
                            }
                            if (komentarzModels2.Count() != 0)
                            {
                                postIndexM.post.zdjecie1 = Convert.ToString(komentarzModels2.Count());
                                postIndexM.komentarz = komentarzModels2.Last();
                                postIndexM.userKomentarz = UserManager.FindById(komentarzModels2.Last().UserId);
                                komentarzModels2.Clear();
                            }
                            else
                            {
                                postIndexM.post.zdjecie1 = "0";
                                postIndexM.komentarz = new KomentarzModel();
                                postIndexM.userKomentarz = new ApplicationUser();
                            }

                            postKomList.Add(new PostyIndexModel(postIndexM));

                        }
                    }
                   
                }
                TempData.Clear();
            }
            else
            {
                foreach (var i in post)
                {
                    if (i.kategoria == id)
                    {
                        postIndexM.post = i;
                        postIndexM.userPost = UserManager.FindById(i.UserId);
                        foreach (var j in komentarzModels)
                        {
                            if (j.PostId == i.Id)
                            {
                                komentarzModels2.Add(j);
                            }
                        }
                        if (komentarzModels2.Count() != 0)
                        {
                            postIndexM.post.zdjecie1 = Convert.ToString(komentarzModels2.Count());
                            postIndexM.komentarz = komentarzModels2.Last();
                            postIndexM.userKomentarz = UserManager.FindById(komentarzModels2.Last().UserId);
                            komentarzModels2.Clear();
                        }
                        else
                        {
                            postIndexM.post.zdjecie1 = "0";
                            postIndexM.komentarz = new KomentarzModel();
                            postIndexM.userKomentarz = new ApplicationUser();
                        }

                        postKomList.Add(new PostyIndexModel(postIndexM));

                    }

                }
            }

            return View(postKomList);
        }

        public ActionResult Komentarze(string id)
        {
            PostModel post = context.Post.Find(Convert.ToInt32(id));
            List<KomentarzModel> komentarzList = context.Komentarz.ToList();
            KomentarzeListModel komentarzeLista = new KomentarzeListModel();
            komentarzeLista.komentarzeIuser = new List<KomentarzIuser>();
            KomentarzIuser komIu = new KomentarzIuser();
            komentarzeLista.post = post;
            komentarzeLista.userPost= UserManager.FindById(post.UserId);
            foreach (var i in komentarzList)
            {
                if (i.PostId == Convert.ToInt32(id))
                {
                    komIu.komentarz = i;
                    komIu.userKomentarz = UserManager.FindById(i.UserId);
                    //Trzeba stworzyć konstruktor w womdelu i tworzyć nowe obiekty
                    komentarzeLista.komentarzeIuser.Add(new KomentarzIuser(komIu));
                }
            }

            return View(komentarzeLista);
        }

        [HttpPost]
        public ActionResult Komentarze([Bind(Include = "PostId,komentarze")] KomentarzModel komentarz)
        {
            string x = Convert.ToString(komentarz.PostId);
            if (komentarz.komentarze == null)
            {
                return RedirectToAction("Komentarze", new
                {
                    id = x
                });
            }
            List<KomentarzModel> kom = context.Komentarz.ToList();
            if (kom.Count == 0)
            {
                komentarz.Id = 1;
            }
            else
            {
                komentarz.Id = kom.Last().Id + 1;
            }
            komentarz.UserId = User.Identity.GetUserId();
            komentarz.kiedyNapisane = DateTime.Now;
            context.Komentarz.Add(komentarz);
            context.SaveChanges();
            return RedirectToAction("Komentarze", new {
                id=x
            });
        }

        public ActionResult DodajPost()
        {
            return View();
        }

        

        [HttpPost]
        public ActionResult DodajPost([Bind(Include = "post,kategoria,temat")] PostModel postModel)
        {
            postModel.kiedyNapisane = DateTime.Now;
            int id = context.Post.OrderByDescending(x => postModel.Id).FirstOrDefault().Id;
            postModel.Id = id + 1;
            postModel.UserId = User.Identity.GetUserId();
            context.Post.Add(postModel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EdytujPost(string id)
        {
            PostModel post = context.Post.Find(Convert.ToInt32(id));
            return View(post);
        }

        [HttpPost]
        public ActionResult EdytujPost([Bind(Include = "id,userId,kiedyNapisane,post,temat,kategoria,zdjecie1,zdjecie2,zdjecie3,zdjecie4")] PostModel postModel)
        {

            context.Entry(postModel).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("MojePosty", "Account", new { postModel.UserId });

        }

        // GET: Forum/Details/5
        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        PostModel postModel = db.Post.Find(id);
        //        if (postModel == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(postModel);
        //    }

        //    // GET: Forum/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Forum/Create
        //    // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        //    // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "id,userId,kiedyNapisane,post,kategoria,zdjecie1,zdjecie2,zdjecie3,zdjecie4")] PostModel postModel)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Post.Add(postModel);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        return View(postModel);
        //    }

        //    // GET: Forum/Edit/5
        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        PostModel postModel = db.Post.Find(id);
        //        if (postModel == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(postModel);
        //    }

        //    // POST: Forum/Edit/5
        //    // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        //    // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "id,userId,kiedyNapisane,post,kategoria,zdjecie1,zdjecie2,zdjecie3,zdjecie4")] PostModel postModel)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(postModel).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(postModel);
        //    }

        //    // GET: Forum/Delete/5
        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        PostModel postModel = db.Post.Find(id);
        //        if (postModel == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(postModel);
        //    }

        //    // POST: Forum/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        PostModel postModel = db.Post.Find(id);
        //        db.Post.Remove(postModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //}
    }
}
