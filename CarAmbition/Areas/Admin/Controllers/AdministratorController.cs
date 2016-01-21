using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarAmbition.Models;
using PagedList.Mvc;
using PagedList;

namespace CarAmbition.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdministratorController : Controller
    {
        //
        // GET: /Administrator/
        CarEntities db = new CarEntities();
        public ActionResult Index(int? page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            List<NguoiDung> user = db.NguoiDungs.Where(w => w.PhanQuyens.Any(k => k.Quyen.TenQuyen == "admin")).OrderBy(o => o.TaiKhoan).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            return View(user.ToPagedList(pageNumber, pageSize));
        }
    }
}