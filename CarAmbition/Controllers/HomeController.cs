using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarAmbition.Models;

namespace CarAmbition.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        CarEntities db = new CarEntities();

        public ActionResult Home()
        {
            var list = db.BanTins.OrderByDescending(o => o.NgayDang).Take(8).ToList();
            var expired = db.BanTins.ToList();
            foreach (var item in expired)
            {
                DateTime t1 = DateTime.Now;
                DateTime t2 = (DateTime)item.NgayDang;
                double dem = (t1 - t2).TotalDays;
                if (dem > 30)
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
            return View(list);
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult DetailView(int MaBanTin = 0)
        {
            BanTin deals = db.BanTins.SingleOrDefault(n => n.MaBanTin == MaBanTin);
            if (deals == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(deals);
        }
    }
}
