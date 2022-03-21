using OyunİncelemeSitesiProjesi.DAL;
using OyunİncelemeSitesiProjesi.DAL.Concrete.Repositories;
using OyunİncelemeSitesiProjesi.Models;
using OyunİncelemeSitesiProjesi.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace OyunİncelemeSitesiProjesi.Controllers
{
    public class OyunController : Controller
    {
        Oyun_VM oyunvm = new Oyun_VM();
        OyunContext db = new OyunContext();
        GenericRepository<Oyun> oyun = new GenericRepository<Oyun>();
        GenericRepository<OyunTur> oyunTur = new GenericRepository<OyunTur>();
        GenericRepository<OyunPlatform> oyunPlatform = new GenericRepository<OyunPlatform>();
        GenericRepository<Yorum> yorum = new GenericRepository<Yorum>();
        GenericRepository<Uye> uye = new GenericRepository<Uye>();
        GenericRepository<Sepet> sepet = new GenericRepository<Sepet>();

        // GET: Oyun

        public ActionResult AnaSayfa(string Ara, int sayfa = 1)
        {
            bool? yok = (bool?)TempData["yok"];
            bool? user = (bool?)TempData["user"];
            bool? zatenVar = (bool?)TempData["ZatenVar"];
            if (yok == true)
            {
                ModelState.AddModelError("HATA", "Kullanıcı Adı veya Şifre Yanlış...");
            }

            if (user == true)
            {
                ModelState.AddModelError("user", "Oturum Açıldı");
            }

            if (zatenVar == true)
            {
                ModelState.AddModelError("ZatenVar", "Bu Kullanıcı Adı Zaten Kullanılıyor");
            }

            if (Ara == null || Ara == "")
            {
                oyunvm.OyunList = oyun.Listele().ToPagedList(sayfa, 4);
                return View(oyunvm);
            }
            else
            {
                oyunvm.OyunList = oyun.Listele(x => x.OyunAd.Contains(Ara)).ToPagedList(sayfa, 4);
                return View(oyunvm);
            }
        }

        public ActionResult Detay(int id)
        {
            oyunvm.OyunEntity = db.Oyunlar.Find(id);
            oyunvm.OyunTurList = oyunTur.Listele(x => x.OyunID == id);
            oyunvm.OyunPlatformList = oyunPlatform.Listele(x => x.OyunID == id);
            oyunvm.YorumList = yorum.Listele(x => x.OyunID == id).OrderByDescending(x => x.Tarih);
            return View(oyunvm);
        }
        public ActionResult Tur(int id, int sayfa = 1)
        {
            oyunvm.TurEntity = db.Turler.Find(id);
            oyunvm.OyunTurList = oyunTur.Listele(x => x.TurID == id).ToPagedList(sayfa, 4);
            return View(oyunvm);
        }
        public ActionResult Platform(int id, int sayfa = 1)
        {
            oyunvm.PlatformEntity = db.Platformlar.Find(id);
            oyunvm.OyunPlatformList = oyunPlatform.Listele(x => x.PlatformID == id).ToPagedList(sayfa, 4);
            return View(oyunvm);
        }

        [HttpPost]
        public ActionResult Kaydol(Oyun_VM oyun_vm)
        {

            if (ModelState.IsValid)
            {
                if (db.Uyeler.FirstOrDefault(x => x.Rumuz == oyun_vm.UyeEntity.Rumuz) == null)
                {
                    MD5 md5 = MD5.Create();
                    byte[] hashdata = md5.ComputeHash(Encoding.UTF8.GetBytes(oyun_vm.UyeEntity.Sifre));

                    string strHashedSifre = "";

                    for (int i = 0; i < hashdata.Length; i++)
                    {
                        strHashedSifre += hashdata[i].ToString("x2");
                    }
                    oyun_vm.UyeEntity.Sifre = strHashedSifre;


                    uye.Ekle(oyun_vm.UyeEntity);

                    return RedirectToAction("AnaSayfa");
                }
                else
                {
                    TempData["ZatenVar"] = true;
                    return RedirectToAction("AnaSayfa");
                }
            }
            else
            {
                return RedirectToAction("AnaSayfa");
            }
        }
        [HttpPost]
        public ActionResult Giris(Oyun_VM oyun_vm)
        {
            if (oyun_vm.UyeEntity.Rumuz != null || oyun_vm.UyeEntity.Sifre != null)
            {
                MD5 md5 = MD5.Create();
                byte[] hashdata = md5.ComputeHash(Encoding.UTF8.GetBytes(oyun_vm.UyeEntity.Sifre));

                string strHashedSifre = "";

                for (int i = 0; i < hashdata.Length; i++)
                {
                    strHashedSifre += hashdata[i].ToString("x2");
                }
                var girisinfo = db.Uyeler.FirstOrDefault(x => x.Rumuz == oyun_vm.UyeEntity.Rumuz && x.Sifre == strHashedSifre);

                if (girisinfo != null)
                {

                    if (girisinfo.Rol == "admin")
                    {
                        FormsAuthentication.SetAuthCookie(oyun_vm.UyeEntity.Rumuz, true);
                        Session["Rumuz"] = oyun_vm.UyeEntity.Rumuz;
                        Session.Timeout = 5;
                        TempData["Rumuz"] = "Hoşgeldin " + oyun_vm.UyeEntity.Rumuz + "";
                        return RedirectToAction("Index", "AdminOyunlar");
                    }
                    else
                    {
                        TempData["user"] = true;
                        FormsAuthentication.SetAuthCookie(oyun_vm.UyeEntity.Rumuz, true);
                        Session["Rumuz"] = oyun_vm.UyeEntity.Rumuz;
                        Session.Timeout = 5;
                        TempData["Rumuz"] = "Hoşgeldin " + oyun_vm.UyeEntity.Rumuz + "";
                        return RedirectToAction("AnaSayfa");
                    }

                }
                else
                {
                    TempData["yok"] = true;
                    return RedirectToAction("AnaSayfa");
                }
            }
            else
            {
                TempData["yok"] = true;
                return RedirectToAction("AnaSayfa");
            }

        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AnaSayfa", "Oyun");
        }

        [HttpPost]
        public ActionResult YorumYap(Oyun_VM oyun_vm)
        {
            string rumuz = (string)Session["Rumuz"];
            oyun_vm.YorumEntity.OyunID = oyun_vm.OyunEntity.OyunID;
            oyun_vm.YorumEntity.UyeID = db.Uyeler.Where(x => x.Rumuz == rumuz).Select(x => x.UyeID).FirstOrDefault();
            oyun_vm.YorumEntity.Tarih = DateTime.Now;
            yorum.Ekle(oyun_vm.YorumEntity);
            return RedirectToAction("Detay/" + oyun_vm.OyunEntity.OyunID + "");
        }

        public ActionResult SepeteEkle(int id)
        {
            string rumuz = (string)Session["Rumuz"];
            int uyeid = db.Uyeler.Where(x => x.Rumuz == rumuz).Select(x => x.UyeID).FirstOrDefault();
            if (db.Sepet.FirstOrDefault(x => x.UyeID == uyeid && x.OyunID == id) == null)
            {
                sepet.Ekle(new Sepet { OyunID = id, UyeID = uyeid });
                return RedirectToAction("Detay/" + id + "");
            }
            else
            {
                return RedirectToAction("Detay/" + id + "");
            }
        }
        public ActionResult Sepet()
        {
            string rumuz = (string)Session["Rumuz"];
            int uyeid = db.Uyeler.Where(x => x.Rumuz == rumuz).Select(x => x.UyeID).FirstOrDefault();
            oyunvm.SepetEntity = db.Sepet.Find(uyeid);
            oyunvm.SepetList = sepet.Listele(x => x.UyeID == uyeid);
            return View(oyunvm);
        }

        public ActionResult SepettenCikar(int id)
        {
            Sepet sepet = db.Sepet.Find(id);
            db.Sepet.Remove(sepet);
            db.SaveChanges();
            return RedirectToAction("Sepet");
        }
        public ActionResult Hakkımda()
        {
            return View();
        }

        public ActionResult İletişim()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult İletişim(string Yazı)
        //{
        //    string to = "mutlu.ekinci@hotmail.com";
        //    string from = "mutlu.e@hotmail.com";
        //    MailMessage message = new MailMessage(from, to);

        //    string mailbody = Yazı;
        //    message.Subject = "Oyun Dünyam";
        //    message.Body = mailbody;
        //    message.BodyEncoding = Encoding.UTF8;
        //    message.IsBodyHtml = true;
        //    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        //    System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("Mutlu Ekinci", "*********");
        //    client.EnableSsl = true;
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = basicCredential1;

        //    client.Send(message);

        //    return RedirectToAction("AnaSayfa");
        //      not implemented    
        //}


    }

}