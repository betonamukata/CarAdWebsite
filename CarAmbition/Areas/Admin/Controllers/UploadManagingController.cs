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
    public class UploadManagingController : Controller
    {
        //
        // GET: /UploadManaging/
        CarEntities db = new CarEntities();
        public ActionResult Upload()
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            return View();
        }

        [HttpPost]
        public ActionResult Image(FormCollection f, int? page)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            string fKeyWord = f["uploadTxt"].ToString();
            ViewBag.KeyWord = fKeyWord;
            List<Xe> imageList = db.Xes.Where(w => w.HangXe.Contains(fKeyWord)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 4;
            if (imageList.Count > 0)
            {
                ViewBag.Flag = true;
                return View(imageList.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Flag = false;
            return View();
        }

        [HttpGet]
        public ActionResult Image(int? page, string car)
        {
            List<BangTam> tam = db.BangTams.ToList();
            Session["Quantity"] = tam.Count();
            List<BanTin> list = db.BanTins.ToList();
            Session["Count"] = list.Count();
            ViewBag.Page = page;
            ViewBag.KeyWord = car;
            List<Xe> imageList = db.Xes.Where(w => w.HangXe.Contains(car)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 4;
            if (imageList.Count > 0)
            {
                ViewBag.Flag = true;
                return View(imageList.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Flag = false;
            return View();
        }
    }
}