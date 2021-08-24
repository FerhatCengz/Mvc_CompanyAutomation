using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPerInfo.Models.Entity;
namespace MvcPerInfo.Controllers
{
    public class PerIslemController : Controller
    {
        // GET: PerIslem
        Db_MvcPersonelEntities db = new Db_MvcPersonelEntities();
        public ActionResult Index()
        {
            var query = db.Tbl_Gunler.ToList();
            //var query = (from x in db.Tbl_Gunler where x.Durum != false select x).ToList();
            List<SelectListItem> listele = (from x in db.Tbl_Gunler.ToList() where x.Durum != false select new SelectListItem { Value = x.ID.ToString(), Text = x.GUNLER + "(" + x.Vardiya + ")" }).ToList();
            ViewBag.lst = listele;

            return View(query);
        }

        [HttpPost]
        public JsonResult Index(Tbl_Gunler p1)
        {
            var user_Session = Session["KAD"].ToString();

            int query = db.Tbl_Gunler.Count(x => x.CalisanKisi == user_Session);
            ViewBag.idCount = query;

            if (query < 3)
            {
                var idBul = db.Tbl_Gunler.Find(p1.ID);
                idBul.CalisanKisi = p1.CalisanKisi;
                idBul.Durum = p1.Durum;
                db.SaveChanges();

            }
            return Json(null, JsonRequestBehavior.AllowGet);

        }


        // Burada Kaldın

        [HttpPost]
        public JsonResult TkvmCalismaEkle(Tbl_CalismaTkvm p1)
        {
            var gun = db.Tbl_Gunler.Where(x => x.ID.ToString() == p1.CalismaGunu).Select(x => x.GUNLER).FirstOrDefault().ToString();
            var vardiya = db.Tbl_Gunler.Where(x => x.ID.ToString() == p1.CalismaGunu).Select(x => x.Vardiya).FirstOrDefault().ToString();

            db.Tbl_CalismaTkvm.Add(p1);
            p1.UserKad = Session["KAD"].ToString();
            p1.CalismaTarihi = DateTime.Now.ToString("dd/MM/yyyy");
            p1.CalismaGunu = gun;
            p1.CaslimaVardiya = vardiya;
            db.SaveChanges();
            return Json(null, JsonRequestBehavior.AllowGet);

        }



        [HttpGet]
        public ActionResult Duyuru()
        {
            var listele = db.Tbl_Duyuru.ToList();
            return View(listele);
        }

        [HttpGet]
        public ActionResult Exit()
        {
            Session.Clear();

            return RedirectToAction("Index", "Login");
        }

    }
}