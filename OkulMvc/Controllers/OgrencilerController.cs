using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkulMvc.Models.EntityFramework;

namespace OkulMvc.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogr = db.TBLOGRENCILERs.ToList();
            return View(ogr);
        }

        [HttpGet]
        public ActionResult YeniOgrEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLERs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i .KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrEkle(TBLOGRENCILER p3)
        {
            var klp = db.TBLKULUPLERs.Where(m=>m.KULUPID == p3.TBLKULUPLER.KULUPID).FirstOrDefault();
            p3.TBLKULUPLER = klp;
            db.TBLOGRENCILERs.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogrenc = db.TBLOGRENCILERs.Find(id);
            db.TBLOGRENCILERs.Remove(ogrenc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCILERs.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKULUPLERs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("OgrenciGetir",ogrenci);
        }
        public ActionResult Guncelle(TBLOGRENCILER p)
        {
            var ogr = db.TBLOGRENCILERs.Find(p.OGRENCIID);
            ogr.OGRAD = p.OGRAD;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRFOTO = p.OGRFOTO;
            ogr.OGRCINSIYET = p.OGRCINSIYET;
            ogr.OGRKULUP = p.TBLKULUPLER.KULUPID;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenciler");
        }
    }
}