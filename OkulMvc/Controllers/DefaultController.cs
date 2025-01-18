using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkulMvc.Models.EntityFramework;

namespace OkulMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.TBLDERSLERs.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDersEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDersEkle(TBLDERSLER p)
        {
            db.TBLDERSLERs.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERSLERs.Find(id);
            db.TBLDERSLERs.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var ders = db.TBLDERSLERs.Find(id);
            return View("DersGetir",ders);
        }
        public ActionResult Guncelle(TBLDERSLER p)
        {
            var ders = db.TBLDERSLERs.Find(p.DERSID);
            ders.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}