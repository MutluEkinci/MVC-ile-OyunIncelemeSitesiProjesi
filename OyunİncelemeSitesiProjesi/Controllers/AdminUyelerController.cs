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
    public class AdminUyelerController : Controller
    {
        private OyunContext db = new OyunContext();
        GenericRepository<Uye> uye = new GenericRepository<Uye>();

        // GET: AdminUyeler
        public ActionResult Index(string Ara, int sayfa = 1)
        {
            if (Ara == null || Ara == "")
            {
                return View(db.Uyeler.ToList().ToPagedList(sayfa, 8));
            }
            else
            {
                return View(uye.Listele(x => x.Rumuz.Contains(Ara)).ToPagedList(sayfa, 4));
            }
        }

        // GET: AdminUyeler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uyeler.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // GET: AdminUyeler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminUyeler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UyeID,AdSoyad,Mail,Rumuz,Sifre,Rol")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                if (db.Uyeler.Where(x => x.Rumuz == uye.Rumuz) == null)
                {
                    db.Uyeler.Add(uye);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(uye);
                }
            }

            return View(uye);
        }

        // GET: AdminUyeler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uyeler.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // POST: AdminUyeler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UyeID,AdSoyad,Mail,Rumuz,Sifre,Rol")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uye);
        }



        public ActionResult Delete(int id)
        {
            Uye uye = db.Uyeler.Find(id);
            db.Uyeler.Remove(uye);
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
