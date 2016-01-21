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
    public class ReviewDealController : Controller
    {
        //
        // GET: /Admin/ReviewDeal/
        CarEntities db = new CarEntities();
        public ActionResult ReviewDeal(int? page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            int pageNumber = (page ?? 1);
            int pageSize = 1;
            return View(db.BangTams.OrderBy(o => o.MaTam).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(int iD, int page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            BangTam deal = db.BangTams.SingleOrDefault(s => s.MaTam == iD);
            if (deal == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            return View(deal);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int iD, int page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            BangTam deal = db.BangTams.SingleOrDefault(s => s.MaTam == iD);
            HinhTam pic = db.HinhTams.SingleOrDefault(s => s.MaTam == iD);
            if (deal == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            db.HinhTams.Remove(pic);
            db.BangTams.Remove(deal);
            db.SaveChanges();
            return RedirectToAction("ReviewDeal");
        }

        [HttpGet]
        public ActionResult Approve(int iD, int page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            BangTam deal = db.BangTams.SingleOrDefault(s => s.MaTam == iD);
            if (deal == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            return View(deal);
        }
        [HttpPost, ActionName("Approve")]
        public ActionResult ConfirmApprove(int iD, int page, BangTam bt, BanTin tin, Xe xe, ChiTietHinh pic)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> lists = db.BanTins.ToList();
            Session["Count"] = lists.Count();
            ViewBag.Page = page;
            BangTam deal = db.BangTams.SingleOrDefault(s => s.MaTam == iD);
            if (deal == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            xe.DanDong = bt.DanDong;
            xe.DangXe = bt.DangXe;
            xe.DonVi = bt.DonVi;
            xe.GiaBan = bt.GiaBan;
            xe.HangXe = bt.HangXe;
            xe.HopSo = bt.HopSo;
            xe.LoaiXe = bt.LoaiXe;
            xe.MauNgoaiThat = bt.MauNgoaiThat;
            xe.MauNoiThat = bt.MauNoiThat;
            xe.MucTieuThu = bt.MucTieuThu;
            xe.NamSanXuat = bt.NamSanXuat;
            xe.NhienLieu = bt.NhienLieu;
            xe.PhienBan = bt.PhienBan;
            xe.SoCho = bt.SoCho;
            xe.SoCua = bt.SoCua;
            xe.SoKm = bt.SoKm;
            xe.TinhTrang = bt.TinhTrang;
            xe.XuatXu = bt.XuatXu;
            db.Xes.Add(xe);
            db.SaveChanges();
            tin.MaXe = db.Xes.OrderByDescending(o => o.MaXe).Select(s => s.MaXe).First();
            tin.TieuDe = bt.TieuDe;
            tin.HinhAnh = db.HinhTams.Where(w => w.MaTam == bt.MaTam).Select(s => s.HinhTo).First();
            tin.NgayDang = bt.NgayDang;
            tin.NoiDung = bt.NoiDung;
            tin.TaiKhoan = bt.TaiKhoan;
            db.BanTins.Add(tin);
            db.SaveChanges();
            int MaTam = int.Parse(db.BangTams.OrderByDescending(o => o.MaTam).Select(s => s.MaTam).First().ToString());
            List<HinhTam> list = db.HinhTams.Where(w => w.MaTam == MaTam).ToList();
            foreach (var item in list)
            {
                pic.HinhNho = item.HinhNho;
                pic.HinhTo = item.HinhTo;
                pic.MaXe = tin.MaXe;
                db.ChiTietHinhs.Add(pic);
                db.SaveChanges();
            }
            db.BangTams.Remove(deal);
            db.SaveChanges();
            return RedirectToAction("ReviewDeal");
        }
    }
}