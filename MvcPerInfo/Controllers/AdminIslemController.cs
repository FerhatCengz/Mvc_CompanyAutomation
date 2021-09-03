using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcPerInfo.Models.Entity;

namespace MvcPerInfo.Controllers
{
    public class AdminIslemController : Controller
    {
        Db_MvcPersonelEntities db = new Db_MvcPersonelEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var kullaniciInfo = Session["KAD"].ToString();

            var sonuc = db.Tbl_Admin.Any(x => x.KAD == kullaniciInfo);

            if (sonuc == false)
            {
                return RedirectToAction("Index", "AdminLogin");
            }

            else
            {
                var listele = db.Tbl_Gunler.Where(x => x.Durum == false).OrderByDescending(y => y.CalisanKisi).ToList();
                return View(listele);

            }
        }


        //[HttpGet]
        //public PartialViewResult Onay()
        //{
        //    var kullaniciInfo = Session["KAD"].ToString();
        //    var sonuc = db.Tbl_Admin.Any(x => x.KAD == kullaniciInfo);

        //    if (sonuc == false)
        //    {
        //        for (int i = 1; i <= 10; i++)
        //        {
        //            var IdBul = db.Tbl_Gunler.Find(i);
        //            IdBul.Durum = true;
        //            IdBul.CalisanKisi = null;
        //            db.SaveChanges();
        //        }
        //    }
        //    return PartialView();

        //}


    }
}