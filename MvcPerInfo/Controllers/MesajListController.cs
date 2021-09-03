using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPerInfo.Models.Entity;
namespace MvcPerInfo.Controllers
{
    public class MesajListController : Controller
    {
        // GET: MesajList
        Db_MvcPersonelEntities db = new Db_MvcPersonelEntities();


        public ActionResult Index()
        {
            var userKad = Session["KAD"].ToString();
            var query = db.Tbl_Kullanici.Where(x => x.KAD != userKad).ToList();
            return View(query);


        }




    }
}