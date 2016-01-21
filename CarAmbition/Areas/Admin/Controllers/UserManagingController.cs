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
    public class UserManagingController : Controller
    {
        //
        // GET: /UserManaging/
        CarEntities db = new CarEntities();

        public ActionResult UserManaging(int? page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            List<NguoiDung> listUser = db.NguoiDungs.OrderBy(o => o.TaiKhoan).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            ViewBag.Quantity = listUser.Count;
            return View(listUser.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Delete(string userName, int? page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            NguoiDung user = db.NguoiDungs.SingleOrDefault(s => s.TaiKhoan == userName);
            if (user == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(string userName, int? page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            NguoiDung user = db.NguoiDungs.SingleOrDefault(s => s.TaiKhoan == userName);
            if (user == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            db.NguoiDungs.Remove(user);
            db.SaveChanges();
            return RedirectToAction("UserManaging");
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Edit(string userName, int? page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            NguoiDung user = db.NguoiDungs.SingleOrDefault(s => s.TaiKhoan == userName);
            if (user == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaQuyen = new SelectList(db.Quyens.OrderBy(o => o.TenQuyen).ToList(), "MaQuyen", "TenQuyen");
            return View(user);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PhanQuyen setRole, int? page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            ViewBag.MaQuyen = new SelectList(db.Quyens.OrderBy(o => o.TenQuyen).ToList(), "MaQuyen", "TenQuyen");
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand("UPDATE PHANQUYEN SET MAQUYEN = {0} WHERE TAIKHOAN = {1}", setRole.MaQuyen, setRole.TaiKhoan);
            }
            return RedirectToAction("UserManaging");
        }
    }
}