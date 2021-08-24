using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPerInfo.Models.Entity;
namespace MvcPerInfo.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        Db_MvcPersonelEntities db = new Db_MvcPersonelEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var userKad = Session["KAD"].ToString();

            var sonuc = db.Tbl_Admin.Any(x => x.KAD == userKad);

            if (sonuc != false)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Index", "AdminLogin");
            }
        }


        [HttpPost]
        public ActionResult Index(Tbl_Duyuru p1)
        {
            db.Tbl_Duyuru.Add(p1);
            db.SaveChanges();
            return View();
        }


        [HttpGet]
        public ActionResult Duzenle()
        {
            var userKad = Session["KAD"].ToString();

            var sonuc = db.Tbl_Admin.Any(x => x.KAD == userKad);

            if (sonuc != false)
            {
                var listele = db.Tbl_Duyuru.ToList();
                return View(listele);
            }
            else
            {
                return RedirectToAction("Index", "AdminLogin");
            }
        }

        [HttpGet]
        public ActionResult Sil(int id)
        {
            var bul = db.Tbl_Duyuru.Find(id);
            db.Tbl_Duyuru.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("Duzenle");
        }
    }
}