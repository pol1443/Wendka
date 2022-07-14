using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wedka.Models;

namespace Wedka.Controllers
{
    public class MapaModelsController : Controller
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
        // GET: MapaModels
        public ActionResult Index()
        {
            List<MapaModel> pom = context.MapaModels.ToList();
            //List<MapaModel> pom2 = new List<MapaModel>();

            //foreach(MapaModel map in pom)
            //{
            //    if (map.UserId == User.Identity.GetUserId())
            //    {
            //        pom2.Add(map);
            //    }
            //}
            return View(pom);
        }

        //[HttpPost]
        //public ActionResult Index([Bind(Include = "tytul,opis,lat,lng")] MapaModel mapaModel)
        //{
        //    List<MapaModel> pom = db.MapaModels.ToList();
        //    if (pom.Count == 0)
        //    {
        //        mapaModel.Id = 1;
        //    }
        //    else
        //    {
        //        mapaModel.Id = pom.Last().Id + 1;
        //    }
        //    mapaModel.UserId = User.Identity.GetUserId();
        //    //mapaModel.ApplicationUser = UserManager.FindById(mapaModel.UserId);
        //    pom.Add(mapaModel);
        //    db.MapaModels.Add(mapaModel);
        //    db.SaveChanges();

        //    return View("Index", pom);
        //}

        // GET: MapaModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapaModel mapaModel = context.MapaModels.Find(id);
            if (mapaModel == null)
            {
                return HttpNotFound();
            }
            return View(mapaModel);
        }

        // GET: MapaModels/Create
        public ActionResult Create()
        {
            List<MapaModel> lista = new List<MapaModel>();
            string id = User.Identity.GetUserId();
            if (User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Index", "MapaModels");
            }
            lista = context.MapaModels.Where(x => x.UserId == id).ToList();
            return View(lista);
        }

        // POST: MapaModels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "tytul,opis,lat,lng")] MapaModel mapaModel)
        {
            List<MapaModel> pom = context.MapaModels.ToList();
            List<MapaModel> lista = new List<MapaModel>();
            string id = User.Identity.GetUserId();
            if (pom.Count == 0)
            {
                mapaModel.Id = 1;
            }
            else
            {
                mapaModel.Id = pom.Last().Id + 1;
            }
            mapaModel.UserId = User.Identity.GetUserId();
            pom.Add(mapaModel);
            context.MapaModels.Add(mapaModel);
            context.SaveChanges();

            lista = context.MapaModels.Where(x => x.UserId == id).ToList();

            return View(lista);
        }

        // GET: MapaModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapaModel mapaModel = context.MapaModels.Find(id);
            if (mapaModel == null)
            {
                return HttpNotFound();
            }
            return View(mapaModel);
        }

        // POST: MapaModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,tytul,opis,lat,lng")] MapaModel mapaModel)
        {
            
                context.Entry(mapaModel).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Create");
            
        }

        // GET: MapaModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapaModel mapaModel = context.MapaModels.Find(id);
            if (mapaModel == null)
            {
                return HttpNotFound();
            }
            context.MapaModels.Remove(mapaModel);
            context.SaveChanges();
            return RedirectToAction("Create");
        }

        // POST: MapaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MapaModel mapaModel = context.MapaModels.Find(id);
            context.MapaModels.Remove(mapaModel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
