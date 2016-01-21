using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using CarAmbition.Models;

namespace CarAmbition.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class DealManagingController : Controller
    {
        //
        // GET: /DealManaging/
        CarEntities db = new CarEntities();
        public ActionResult DealManaging(int? page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            List<BanTin> deal = db.BanTins.OrderBy(o => o.MaBanTin).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 1;
            ViewBag.Quantity = deal.Count;
            return View(deal.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(int iD, int page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            BanTin deal = db.BanTins.SingleOrDefault(s => s.MaBanTin == iD);
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
            BanTin deal = db.BanTins.SingleOrDefault(s => s.MaBanTin == iD);
            if (deal == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            db.BanTins.Remove(deal);
            db.SaveChanges();
            return RedirectToAction("DealManaging");
        }

        public ActionResult ForUser()
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            return View();
        }
        [HttpPost]
        public ActionResult DealForUser(FormCollection f, int? page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            string fKeyWord = f["userTxt"].ToString();
            ViewBag.KeyWord = fKeyWord;
            List<BanTin> deal = db.BanTins.Where(w => w.TaiKhoan.Contains(fKeyWord)).OrderBy(o => o.MaBanTin).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 1;
            if (deal.Count > 0)
            {
                ViewBag.Flag = true;
                return View(deal.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Flag = false;
            return View();
        }
        [HttpGet]
        public ActionResult DealForUser(int? page, string user)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            ViewBag.KeyWord = user;
            List<BanTin> deal = db.BanTins.Where(w => w.TaiKhoan.Contains(user)).OrderBy(o => o.MaBanTin).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 1;
            if (deal.Count > 0)
            {
                ViewBag.Flag = true;
                return View(deal.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Flag = false;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteDealForUser(int iD, int page, string user)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.KeyWord = user;
            ViewBag.Page = page;
            BanTin deal = db.BanTins.SingleOrDefault(s => s.MaBanTin == iD);
            if (deal == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            return View(deal);
        }
        [HttpPost, ActionName("DeleteDealForUser")]
        public ActionResult ConfirmDeleteDealForUser(int iD, int page, string user)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.KeyWord = user;
            ViewBag.Page = page;
            BanTin deal = db.BanTins.SingleOrDefault(s => s.MaBanTin == iD);
            if (deal == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            db.BanTins.Remove(deal);
            db.SaveChanges();
            return RedirectToAction("DealForUser", new { user = user });
        }

        public ActionResult ForCar()
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            return View();
        }

        [HttpPost]
        public ActionResult DealForCar(FormCollection f, int? page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            string fKeyWord = f["carTxt"].ToString();
            ViewBag.KeyWord = fKeyWord;
            List<BanTin> deal = db.BanTins.Where(w => w.Xe.HangXe.Contains(fKeyWord)).OrderBy(o => o.MaBanTin).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 1;
            if (deal.Count > 0)
            {
                ViewBag.Flag = true;
                return View(deal.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Flag = false;
            return View();
        }
        [HttpGet]
        public ActionResult DealForCar(int? page, string car)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            ViewBag.KeyWord = car;
            List<BanTin> deal = db.BanTins.Where(w => w.Xe.HangXe.Contains(car)).OrderBy(o => o.MaBanTin).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 1;
            if (deal.Count > 0)
            {
                ViewBag.Flag = true;
                return View(deal.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Flag = false;
            return View();
        }
        [HttpPost, ActionName("DeleteDealForCar")]
        public ActionResult ConfirmDeleteDealForCar(int iD, int page, string car)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.KeyWord = car;
            ViewBag.Page = page;
            BanTin deal = db.BanTins.SingleOrDefault(s => s.MaBanTin == iD);
            if (deal == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            db.BanTins.Remove(deal);
            db.SaveChanges();
            return RedirectToAction("DealforCar", new { car = car });
        }
        [HttpGet]
        public ActionResult DeleteDealForCar(int iD, int page, string car)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.KeyWord = car;
            ViewBag.Page = page;
            BanTin deal = db.BanTins.SingleOrDefault(s => s.MaBanTin == iD);
            if (deal == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            return View(deal);
        }
    }
}