using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkulMvc.Models.EntityFramework;

namespace OkulMvc.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var klp = db.TBLKULUPLERs.ToList();
            return View(klp);
        }
        [HttpGet]
        public ActionResult YeniKulüpEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulüpEkle(TBLKULUPLER p2)
        {
            db.TBLKULUPLERs.Add(p2);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLERs.Find(id);
            db.TBLKULUPLERs.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulupGetir(int id)
        {
            var kulup = db.TBLKULUPLERs.Find(id);
            return View("KulupGetir",kulup); 
        }
        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var klp = db.TBLKULUPLERs.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index","Kulupler");
        }
    }
}