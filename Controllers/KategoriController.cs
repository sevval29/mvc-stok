using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler=db.Table_kategori.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
            //sayfa yüklenince bunu yap
            //burda sadece sayfaya girince syafayı göstersin istiyoruz.
        }

        [HttpPost]
        public ActionResult YeniKategori(Table_kategori p1)
        {
            //bir şey ekleyince bunu yap

            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Table_kategori.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {

          var kategori = db.Table_kategori.Find(id);



            db.Table_kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori=db.Table_kategori.Find(id);
            return View("KategoriGetir" ,kategori);
        }

        public ActionResult Guncelle(Table_kategori p1)
        {
            var kategori = db.Table_kategori.Find(p1.KategoriId);
            kategori.KategoriAd=p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}