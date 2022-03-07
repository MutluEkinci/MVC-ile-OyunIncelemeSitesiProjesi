
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
using OyunİncelemeSitesiProjesi.Models.ViewModel;
using OyunİncelemeSitesiProjesi.DAL.Concrete.Repositories;

namespace OyunİncelemeSitesiProjesi.Controllers
{

    [Authorize(Roles ="admin")]
    public class AdminOyunlarController : Controller
    {
        Oyun_VM oyun_vm = new Oyun_VM();
        GenericRepository<Oyun> oyun = new GenericRepository<Oyun>();
        GenericRepository<Tur> tur = new GenericRepository<Tur>();
        GenericRepository<OyunTur> oyunTur = new GenericRepository<OyunTur>();
        GenericRepository<Platform> platform = new GenericRepository<Platform>();
        GenericRepository<OyunPlatform> oyunPlatform = new GenericRepository<OyunPlatform>();

        private OyunContext db = new OyunContext();

        // GET: AdminOyunlar
        public ActionResult Index(string Ara, int sayfa = 1)
        {
            if (Ara == null || Ara == "")
            {
                return View(db.Oyunlar.ToList().OrderByDescending(x => x.CikisYili).ToPagedList(sayfa, 8));
            }
            else
            {
                return View(oyun.Listele(x => x.OyunAd.Contains(Ara)).ToPagedList(sayfa, 8));
            }
        }

        // GET: AdminOyunlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oyun_vm.OyunEntity = db.Oyunlar.Find(id);
            oyun_vm.OyunTurList = oyunTur.Listele(x => x.OyunID == id);
            oyun_vm.OyunPlatformList = oyunPlatform.Listele(x => x.OyunID == id);

            if (oyun == null)
            {
                return HttpNotFound();
            }
            return View(oyun_vm);
        }

        // GET: AdminOyunlar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminOyunlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OyunID,OyunAd,Resim,CikisYili,İnceleme,Puan")] Oyun oyun, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                oyun.Resim = file.FileName;
                file.SaveAs(Server.MapPath("~/Images/" + file.FileName + ""));
                db.Oyunlar.Add(oyun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oyun);
        }

        // GET: AdminOyunlar/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oyun_vm.OyunEntity = db.Oyunlar.Find(id);

            OyunTur oyunTurent = new OyunTur();
            oyun_vm.OyunTurList = oyunTur.Listele(x => x.OyunID == id);


            oyun_vm.OyunPlatformList = oyunPlatform.Listele(x => x.OyunID == id);

            if (oyun == null)
            {
                return HttpNotFound();
            }
            return View(oyun_vm);
        }

        public ActionResult TurEkle(int? id)
        {
            OyunTur ot = db.OyunTurleri.Where(m => m.OyunID == id).FirstOrDefault();

            ViewBag.OyunID = new SelectList(db.Oyunlar, "OyunID", "OyunAd");
            ViewBag.TurID = new SelectList(db.Turler, "TurID", "TurAd");
            return View(ot);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TurEkle([Bind(Include = "OyunTurID,OyunID,TurID")] OyunTur oyunTur)
        {
            if (ModelState.IsValid)
            {
                db.OyunTurleri.Add(oyunTur);
                db.SaveChanges();
                return RedirectToAction("Edit/" + oyunTur.OyunID + "");
            }

            ViewBag.OyunID = new SelectList(db.Oyunlar, "OyunID", "OyunAd", oyunTur.OyunID);
            ViewBag.TurID = new SelectList(db.Turler, "TurID", "TurAd", oyunTur.TurID);
            return View(oyunTur);
        }

        public ActionResult TurGuncelle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OyunTur oyunTur = db.OyunTurleri.Find(id);
            if (oyunTur == null)
            {
                return HttpNotFound();
            }
            ViewBag.OyunID = new SelectList(db.Oyunlar, "OyunID", "OyunAd", oyunTur.OyunID);
            ViewBag.TurID = new SelectList(db.Turler, "TurID", "TurAd", oyunTur.TurID);
            return View(oyunTur);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TurGuncelle([Bind(Include = "OyunTurID,OyunID,TurID")] OyunTur oyunTur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oyunTur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit/" + oyunTur.OyunID + "");
            }
            ViewBag.OyunID = new SelectList(db.Oyunlar, "OyunID", "OyunAd", oyunTur.OyunID);
            ViewBag.TurID = new SelectList(db.Turler, "TurID", "TurAd", oyunTur.TurID);
            return View(oyunTur);
        }

        public ActionResult TurSil(int id)
        {
            Oyun_VM oyunvm = new Oyun_VM();
            oyunvm.OyunTurEntity = db.OyunTurleri.Find(id);
            db.OyunTurleri.Remove(oyunvm.OyunTurEntity);
            db.SaveChanges();
            return RedirectToAction("Edit/" + oyunvm.OyunTurEntity.OyunID + "");
        }

        public ActionResult PlatformEkle(int? id)
        {
            OyunPlatform op = db.OyunPlatformları.Where(m => m.OyunID == id).FirstOrDefault();

            ViewBag.OyunID = new SelectList(db.Oyunlar, "OyunID", "OyunAd");
            ViewBag.PlatformID = new SelectList(db.Platformlar, "PlatformID", "PlatformAd");
            return View(op);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlatformEkle([Bind(Include = "OyunPlatformID,OyunID,PlatformID")] OyunPlatform oyunPlatform)
        {
            if (ModelState.IsValid)
            {
                db.OyunPlatformları.Add(oyunPlatform);
                db.SaveChanges();
                return RedirectToAction("Edit/" + oyunPlatform.OyunID + "");
            }

            ViewBag.OyunID = new SelectList(db.Oyunlar, "OyunID", "OyunAd", oyunPlatform.OyunID);
            ViewBag.PlatformID = new SelectList(db.Platformlar, "PlatformID", "PlatformAd", oyunPlatform.PlatformID);
            return View(oyunPlatform);
        }

        public ActionResult PlatformGuncelle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OyunPlatform oyunPlatform = db.OyunPlatformları.Find(id);
            if (oyunPlatform == null)
            {
                return HttpNotFound();
            }
            ViewBag.OyunID = new SelectList(db.Oyunlar, "OyunID", "OyunAd", oyunPlatform.OyunID);
            ViewBag.PlatformID = new SelectList(db.Platformlar, "PlatformID", "PlatformAd", oyunPlatform.PlatformID);
            return View(oyunPlatform);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlatformGuncelle([Bind(Include = "OyunPlatformID,OyunID,PlatformID")] OyunPlatform oyunPlatform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oyunPlatform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit/" + oyunPlatform.OyunID + "");
            }
            ViewBag.OyunID = new SelectList(db.Oyunlar, "OyunID", "OyunAd", oyunPlatform.OyunID);
            ViewBag.PlatformID = new SelectList(db.Platformlar, "PlatformID", "PlatformAd", oyunPlatform.PlatformID);
            return View(oyunPlatform);
        }

        public ActionResult PlatformSil(int id)
        {
            OyunPlatform oyunPlatform = db.OyunPlatformları.Find(id);
            db.OyunPlatformları.Remove(oyunPlatform);
            db.SaveChanges();
            return RedirectToAction("Edit/" + oyunPlatform.OyunID + "");
        }

        // POST: AdminOyunlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "OyunID,OyunAd,Resim,CikisYili,İnceleme,Puan")]
        public ActionResult Edit(Oyun_VM o, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    db.Entry(o.OyunEntity).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    o.OyunEntity.Resim = file.FileName;
                    file.SaveAs(Server.MapPath("~/Images/" + file.FileName + ""));
                    db.Entry(o.OyunEntity).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(o);
        }

        public ActionResult Delete(int id)
        {
            Oyun oyun = db.Oyunlar.Find(id);
            db.Oyunlar.Remove(oyun);
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
