using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.Table_musteri select d;
            return View(degerler.ToList());


           // var degerler = db.Table_musteri.ToList();

          //  return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(Table_musteri p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.Table_musteri
                .Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var müsteri=db.Table_musteri.Find(id);

            db.Table_musteri.Remove(müsteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.Table_musteri.Find(id);

            
            return View("MusteriGetir",musteri);
        }

        public ActionResult Guncelle(Table_musteri p1)
        {
            var musteri = db.Table_musteri.Find(p1.MusteriId);
            musteri.MusteriAd = p1.MusteriAd;
            musteri.müsterisoyad = p1.müsterisoyad;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}