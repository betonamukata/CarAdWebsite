using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarAmbition.Models;
using PagedList;

namespace CarAmbition.Controllers
{
    public class DealController : Controller
    {
        //
        // GET: /Deal/
        CarEntities db = new CarEntities();

        public ActionResult Deal(int? page)
        {
            var expired = db.BanTins.ToList();
            foreach (var item in expired)
            {
                DateTime t1 = DateTime.Now;
                DateTime t2 = (DateTime)item.NgayDang;
                double dem = (t1 - t2).TotalDays;
                if (dem > 15)
                {
                    item.HanDang = true;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    item.HanDang = false;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            ViewBag.Username = this.Request.QueryString["Username"];
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(db.BanTins.OrderByDescending(o => o.NgayDang).ToPagedList(pageNumber, pageSize));
        }
    }
}