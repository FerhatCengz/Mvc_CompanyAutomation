using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPerInfo.Models.Entity;
using System.Web.Security;
namespace MvcPerInfo.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
        Db_MvcPersonelEntities db = new Db_MvcPersonelEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Kullanici p1)
        {

            var userInfo = db.Tbl_Kullanici.FirstOrDefault(x => x.KAD == p1.KAD && x.PASS == p1.PASS && p1.LoginDay != "Sat" && p1.LoginDay != "Sun");

            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.KAD, false);
                Session["KAD"] = userInfo.KAD.ToString();
                return RedirectToAction("Index", "PerIslem");
            }

            else
            {
                return View();
            }
        }

        [HttpGet]
        public PartialViewResult AdminLgn()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AdminLgn(Tbl_Admin p1)
        {
            return PartialView();
        }
    }
}