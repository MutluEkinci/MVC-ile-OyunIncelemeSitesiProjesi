using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OyunİncelemeSitesiProjesi.DAL;
using OyunİncelemeSitesiProjesi.DAL.Concrete.Repositories;
using OyunİncelemeSitesiProjesi.Models;

namespace OyunİncelemeSitesiProjesi.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminTurlerController : Controller
    {
        private OyunContext db = new OyunContext();

        // GET: AdminTurler
        public ActionResult Index()
        {
            return View(db.Turler.ToList());
        }

        // GET: AdminTurler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tur tur = db.Turler.Find(id);
            if (tur == null)
            {
                return HttpNotFound();
            }
            return View(tur);
        }

        // GET: AdminTurler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminTurler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TurID,TurAd")] Tur tur)
        {
            if (ModelState.IsValid)
            {
                db.Turler.Add(tur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tur);
        }

        // GET: AdminTurler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tur tur = db.Turler.Find(id);
            if (tur == null)
            {
                return HttpNotFound();
            }
            return View(tur);
        }

        // POST: AdminTurler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TurID,TurAd")] Tur tur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tur);
        }

        public ActionResult Delete(int id)
        {
            Tur tur = db.Turler.Find(id);
            db.Turler.Remove(tur);
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
