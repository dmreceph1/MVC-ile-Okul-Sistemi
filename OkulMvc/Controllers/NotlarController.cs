using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkulMvc.Models.EntityFramework;
using OkulMvc.Models;

namespace OkulMvc.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var not = db.TBLNOTLARs.ToList();
            return View(not);
        }

        [HttpGet]
        public ActionResult YeniNotEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniNotEkle(TBLNOTLAR p4)
        {
            db.TBLNOTLARs.Add(p4);
            db.SaveChanges();
            return View();
        }
        public ActionResult NotGetir(int id)
        {
            var not = db.TBLNOTLARs.Find(id);
            return View("NotGetir", not);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model,TBLNOTLAR p,int SINAV1=0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        {
            if (model.islem == "HESAPLA")
            {
                double ORTALAMA = ((SINAV1 + SINAV2 + SINAV3 + PROJE) / 4);
                ViewBag.ort = ORTALAMA;
            }
            if (model.islem == "NOTGUNCELLE")
            {
                var not = db.TBLNOTLARs.Find(p.NOTID);
                not.SINAV1 = p.SINAV1;
                not.SINAV2 = p.SINAV2;
                not.SINAV3 = p.SINAV3;
                not.PROJE = p.PROJE;
                not.ORTALAMA = p.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index","Notlar");
            }
            return View();
        }
    }
}