using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPerInfo.Models.Entity;
namespace MvcPerInfo.Controllers
{
    public class IslemlerController : Controller
    {
        Db_MvcPersonelEntities db = new Db_MvcPersonelEntities();

        [HttpGet]
        public ActionResult Index()
        {
            string Userinfo = Session["KAD"].ToString();

            var sonuc = db.Tbl_Admin.Any(x => x.KAD == Userinfo);

            if (sonuc == false)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Index(Tbl_Kullanici p1)
        {
            if (p1.ADI == "Sifirila")
            {
                for (int i = 1; i <= 10; i++)
                {
                    var bul = db.Tbl_Gunler.Find(i);
                    bul.Durum = true;
                    bul.CalisanKisi = null;
                    db.SaveChanges();
                }
                return View();
            }

            else
            {
                string text = "";
                var sonuc = db.Tbl_Kullanici.Any(x => x.KAD == p1.KAD);
                if (sonuc == false)
                {
                    text = "Başarılı";
                    var ekle = db.Tbl_Kullanici.Add(p1);
                    db.SaveChanges();
                    return View();

                }
                else
                {
                    text = "Böyle bir kullanıcı Adı Mevcuttur";
                    ViewBag.hata = text;
                    return View();
                }
            }


        }

    }
}