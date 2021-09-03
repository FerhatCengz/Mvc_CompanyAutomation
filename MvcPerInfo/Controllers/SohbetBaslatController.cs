using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPerInfo.Models.Entity;

namespace MvcPerInfo.Controllers
{
    public class SohbetBaslatController : Controller
    {
        // GET: SohbetBaslat
        Db_MvcPersonelEntities db = new Db_MvcPersonelEntities();

        [HttpGet]
        public ActionResult Index(string id)
        {
            ViewBag.idal = id;
            var alici = Session["KAD"].ToString();

            var bul = db.Tbl_Kullanici.Find(id);
            ViewBag.resimYolu = bul.ResimYolu;
            ViewBag.AD = bul.ADI;
            ViewBag.SOYAD = bul.SOYADI;

            return View();
            //|| x.Alici == id && x.Gonderen == alici

            //var ss = db.Tbl_MsjKad.Where(x => x.Alici == alici && x.Gonderen == id).ToList();
            //var ss = db.Tbl_MsjKad.ToList();
        }

        [HttpPost]
        public ActionResult Index(Tbl_MsjKad p1)
        {
            db.Tbl_MsjKad.Add(p1);
            p1.Durum = false;
            p1.Tarih = DateTime.Now.ToString("dd/MM/yyyy");
            db.SaveChanges();

            //return Json(null, JsonRequestBehavior.AllowGet);
            return View();
        }
    }
}