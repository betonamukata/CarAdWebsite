using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarAmbition.Models;

namespace CarAmbition.Controllers
{
    public class CompareController : Controller
    {
        //
        // GET: /Compare/
        CarEntities db = new CarEntities();
        public ActionResult Compare()
        {
            List<Xe> car = db.Xes.OrderBy(o => o.HangXe).ThenBy(t => t.LoaiXe).ThenBy(t => t.PhienBan).ThenBy(t => t.NamSanXuat).ToList();
            car.Count();
            return View(car);
        }
	}
}