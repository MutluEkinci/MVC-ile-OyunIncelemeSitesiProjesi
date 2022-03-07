using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OyunİncelemeSitesiProjesi.DAL;
using OyunİncelemeSitesiProjesi.Models;
using PagedList.Mvc;
using PagedList;
using OyunİncelemeSitesiProjesi.DAL.Concrete.Repositories;

namespace OyunİncelemeSitesiProjesi.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminYorumlarController : Controller
    {
        private OyunContext db = new OyunContext();
        GenericRepository<Yorum> yorum = new GenericRepository<Yorum>();

        // GET: AdminYorumlar
        public ActionResult Index(string Ara, int sayfa = 1)
        {
            if (Ara == null || Ara == "")
            {
                var yorumlar = db.Yorumlar.Include(y => y.Oyun).Include(y => y.Uye);
                return View(yorumlar.ToList().OrderByDescending(x => x.Tarih).ToPagedList(sayfa, 8));
            }
            else
            {
                var yorumlar = db.Yorumlar.Include(y => y.Oyun).Include(y => y.Uye);
                return View(yorum.Listele(x => x.Oyun.OyunAd.Contains(Ara)).ToPagedList(sayfa, 8));
            }
        }

        // GET: AdminYorumlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorumlar.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        // GET: AdminYorumlar/Create
        public ActionResult Create()
        {
            ViewBag.OyunID = new SelectList(db.Oyunlar, "OyunID", "OyunAd");
            ViewBag.UyeID = new SelectList(db.Uyeler, "UyeID", "AdSoyad");
            return View();
        }

        // POST: AdminYorumlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YorumID,UyeID,OyunID,YorumYazı,Tarih")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.Yorumlar.Add(yorum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OyunID = new SelectList(db.Oyunlar, "OyunID", "OyunAd", yorum.OyunID);
            ViewBag.UyeID = new SelectList(db.Uyeler, "UyeID", "AdSoyad", yorum.UyeID);
            return View(yorum);
        }

        // GET: AdminYorumlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorumlar.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            ViewBag.OyunID = new SelectList(db.Oyunlar, "OyunID", "OyunAd", yorum.OyunID);
            ViewBag.UyeID = new SelectList(db.Uyeler, "UyeID", "AdSoyad", yorum.UyeID);
            return View(yorum);
        }

        // POST: AdminYorumlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YorumID,UyeID,OyunID,YorumYazı,Tarih")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OyunID = new SelectList(db.Oyunlar, "OyunID", "OyunAd", yorum.OyunID);
            ViewBag.UyeID = new SelectList(db.Uyeler, "UyeID", "AdSoyad", yorum.UyeID);
            return View(yorum);
        }




        public ActionResult Delete(int id)
        {
            Yorum yorum = db.Yorumlar.Find(id);
            db.Yorumlar.Remove(yorum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
