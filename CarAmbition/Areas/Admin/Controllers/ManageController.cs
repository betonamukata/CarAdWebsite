using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarAmbition.Models;

namespace CarAmbition.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ManageController : Controller
    {
        //
        // GET: /Manage/
        CarEntities db = new CarEntities();
        public ActionResult Manage()
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            return View();
        }
    }
}