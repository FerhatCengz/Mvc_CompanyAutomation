using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPerInfo.Models.Entity;

namespace MvcPerInfo.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        Db_MvcPersonelEntities db = new Db_MvcPersonelEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Kullanici p1)
        {
            var idTut = db.Tbl_Kullanici.Find(p1.KAD);
            idTut.ADI = p1.ADI;
            idTut.SOYADI = p1.SOYADI;
            idTut.Email = p1.Email;

            db.SaveChanges();


            return View();
        }


        [HttpPost]
        public ActionResult dropzoneUpload(Tbl_Kullanici p1, string resimAdi)
        {
            if (Request.Files.Count > 0)
            {
                var kadBul = db.Tbl_Kullanici.Find(resimAdi);
                kadBul.ResimAdi = Path.GetFileName(Request.Files[0].FileName);
                kadBul.ResimYolu = "/Resimler/" + resimAdi + "_" + kadBul.ResimAdi;
                Request.Files[0].SaveAs(Server.MapPath(kadBul.ResimYolu));
                db.SaveChanges();

            }


            return View();
        }

    }
}