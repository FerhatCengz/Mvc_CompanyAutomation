using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcPerInfo.Models.Entity;
namespace MvcPerInfo.Controllers
{
    public class GelenKController : Controller
    {
        Db_MvcPersonelEntities db = new Db_MvcPersonelEntities();
        // GET: GelenK
        [HttpGet]
        public ActionResult Index(int sayfa = 1)
        {
            var userKullanici = Session["KAD"].ToString();

            var qq = db.Tbl_MsjKad.Where(x => x.Alici == userKullanici && x.Durum == false).OrderByDescending(x => x.MesajID).ToList().ToPagedList(sayfa, 8);

            var countGelenK = db.Tbl_MsjKad.Where(x => x.Alici == userKullanici).Count(x => x.Durum == false).ToString();

            ViewBag.GELENKUTUSU = countGelenK;

            return View(qq);
        }

        [HttpGet]
        public ActionResult OkunmusMesajlar(int sayfa = 1)
        {
            var userKullanici = Session["KAD"].ToString();

            var qq = db.Tbl_MsjKad.Where(x => x.Alici == userKullanici && x.Durum == true).OrderByDescending(x => x.MesajID).ToList().ToPagedList(sayfa, 8);
            var countGelenK = db.Tbl_MsjKad.Where(x => x.Alici == userKullanici).Count(x => x.Durum == false).ToString();
            ViewBag.GELENKUTUSU = countGelenK;

            return View(qq);
        }

        [HttpGet]
        public ActionResult GidenMessage(int sayfa = 1)
        {
            var userKullanici = Session["KAD"].ToString();

            var qq = db.Tbl_MsjKad.Where(x => x.Gonderen == userKullanici).OrderByDescending(x => x.MesajID).ToList().ToPagedList(sayfa, 8);
            var countGelenK = db.Tbl_MsjKad.Where(x => x.Alici == userKullanici).Count(x => x.Durum == false).ToString();
            ViewBag.GELENKUTUSU = countGelenK;

            return View(qq);
        }



        [HttpGet]
        public ActionResult MessageRead(int id)
        {
            var bul = db.Tbl_MsjKad.Find(id);
            bul.Durum = true;
            db.SaveChanges();

            var mesajGetir = db.Tbl_MsjKad.FirstOrDefault(x => x.MesajID == id);
            ViewBag.gonderen = mesajGetir.Gonderen;
            ViewBag.gonderenTarih = mesajGetir.Tarih;

            return View(mesajGetir);
        }

        [HttpPost]
        public JsonResult MesajSil(Tbl_MsjKad p1)
        {
            string sessionInfo = Session["KAD"].ToString();

            var getirMesaj = db.Tbl_MsjKad.Where(x => x.Durum == true && x.Alici == sessionInfo).ToList();
            var donenAdet = db.Tbl_MsjKad.Where(x => x.Durum == true && x.Alici == sessionInfo).Count();

            for (int i = 0; i <= donenAdet - 1; i++)
            {
                var id = getirMesaj[i].MesajID;

                var bul = db.Tbl_MsjKad.Find(id);
                db.Tbl_MsjKad.Remove(bul);
                db.SaveChanges();

            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MesajSilGelenK(Tbl_MsjKad p1)
        {
            string sessionInfo = Session["KAD"].ToString();

            var getirMesaj = db.Tbl_MsjKad.Where(x => x.Alici == sessionInfo).ToList();
            var donenAdet = db.Tbl_MsjKad.Where(x => x.Alici == sessionInfo).Count();

            for (int i = 0; i <= donenAdet - 1; i++)
            {
                var id = getirMesaj[i].MesajID;

                var bul = db.Tbl_MsjKad.Find(id);
                db.Tbl_MsjKad.Remove(bul);
                db.SaveChanges();

            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult MesajSilileti(Tbl_MsjKad p1)
        {
            string sessionInfo = Session["KAD"].ToString();

            var getirMesaj = db.Tbl_MsjKad.Where(x => x.Gonderen == sessionInfo).ToList();
            var donenAdet = db.Tbl_MsjKad.Where(x => x.Gonderen == sessionInfo).Count();

            for (int i = 0; i <= donenAdet - 1; i++)
            {
                var id = getirMesaj[i].MesajID;

                var bul = db.Tbl_MsjKad.Find(id);
                db.Tbl_MsjKad.Remove(bul);
                db.SaveChanges();

            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult TekTekSil(Tbl_MsjKad p1)
        {
            var bul = db.Tbl_MsjKad.Find(p1.MesajID);
            db.Tbl_MsjKad.Remove(bul);
            db.SaveChanges();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

    }
}