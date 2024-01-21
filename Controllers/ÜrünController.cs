using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class ÜrünController : Controller
    {
        // GET: Ürün

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.Table_urun.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler=(from  i in db.Table_kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text=i.KategoriAd,
                                               Value=i.KategoriId.ToString()
                                           }).ToList();
           ViewBag.dgr=degerler;
                                           return View();
            //sayfa yüklenince bunu yap
            //burda sadece sayfaya girince syafayı göstersin istiyoruz.
        }

        [HttpPost]
        public ActionResult UrunEkle(Table_urun p1)
        {
            var ktg = db.Table_kategori.Where(m => m.KategoriId == p1.Table_kategori.KategoriId).FirstOrDefault();
            p1.Table_kategori = ktg;
            //bir şey ekleyince bunu yap
            db.Table_urun.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun=db.Table_urun.Find(id);
            db.Table_urun.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.Table_urun.Find(id);

            List<SelectListItem> degerler = (from i in db.Table_kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(Table_urun p1)
        {
            var urun = db.Table_urun.Find(p1.UrunId);
            urun.UrunAd=p1.UrunAd;
            urun.Marka = p1.Marka;
            urun.Stok=p1.Stok;
            urun.Fıyat = p1.Fıyat;
            //urun.UrunKategori=p1.UrunKategori;
            var ktg = db.Table_kategori.Where(m => m.KategoriId == p1.Table_kategori.KategoriId).FirstOrDefault();
            urun.UrunKategori = ktg.KategoriId;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
