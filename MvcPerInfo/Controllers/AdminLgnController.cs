using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcPerInfo.Models.Entity;
namespace MvcPerInfo.Controllers
{
    [AllowAnonymous]
    public class AdminLgnController : Controller
    {
        Db_MvcPersonelEntities db = new Db_MvcPersonelEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Admin p1)
        {

            var userInfo = db.Tbl_Admin.FirstOrDefault(x => x.KAD == p1.KAD && x.PASS == p1.PASS);

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
    }
}