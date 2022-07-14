//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Wedka.Models;

//namespace Wedka.Controllers
//{
//    public class PostModelsController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: PostModels
//        public ActionResult Index()
//        {
//            return View(db.Post.ToList());
//        }

//        // GET: PostModels/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            PostModel postModel = db.Post.Find(id);
//            if (postModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(postModel);
//        }

//        // GET: PostModels/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: PostModels/Create
//        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
//        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,UserId,kiedyNapisane,post,kategoria,zdjecie1,zdjecie2,zdjecie3,zdjecie4,iloscKom,temat")] PostModel postModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Post.Add(postModel);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(postModel);
//        }

//        // GET: PostModels/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            PostModel postModel = db.Post.Find(id);
//            if (postModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(postModel);
//        }

//        // POST: PostModels/Edit/5
//        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
//        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,UserId,kiedyNapisane,post,kategoria,zdjecie1,zdjecie2,zdjecie3,zdjecie4,iloscKom,temat")] PostModel postModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(postModel).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(postModel);
//        }

//        // GET: PostModels/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            PostModel postModel = db.Post.Find(id);
//            if (postModel == null)
//            {
//                return HttpNotFound();
//            }
//            db.Post.Remove(postModel);
//            db.SaveChanges();
//            return RedirectToAction("MojePosty","Account",new {postModel.UserId});
//        }

//        // POST: PostModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            PostModel postModel = db.Post.Find(id);
//            db.Post.Remove(postModel);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
