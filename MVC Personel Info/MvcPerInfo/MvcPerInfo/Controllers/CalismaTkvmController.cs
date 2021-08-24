using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPerInfo.Models.Entity;
namespace MvcPerInfo.Controllers
{
    public class CalismaTkvmController : Controller
    {
        // GET: CalismaTkvm
        Db_MvcPersonelEntities db = new Db_MvcPersonelEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var userAl = Session["KAD"].ToString();
            var listele = db.Tbl_CalismaTkvm.Where(x => x.UserKad == userAl).ToList();
            return View(listele);
        }

    }
}