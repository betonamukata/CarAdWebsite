using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using CarAmbition.Models;

namespace CarAmbition.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        CarEntities db = new CarEntities();
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult SearchResult()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchResult(FormCollection f, int? page)
        {
            string hangXe = f["HangXe"].ToString();
            int namSanXuat = Convert.ToInt32(f["NamSanXuat"]);
            int giaBanTu = Convert.ToInt32(f["GiaBanTu"]);
            int denGiaBan = Convert.ToInt32(f["DenGiaBan"]);
            bool tinhTrang = Convert.ToBoolean(f["TinhTrang"]);
            bool donVi = Convert.ToBoolean(f["DonVi"]);
            ViewBag.KeyWord = hangXe;
            List<BanTin> listDeal;
            if (namSanXuat == 1992)
            {
                listDeal = db.BanTins.Where(w => w.Xe.HangXe == hangXe && w.Xe.NamSanXuat < 1992 && w.Xe.TinhTrang == tinhTrang
                    && w.Xe.DonVi == donVi && w.Xe.GiaBan >= giaBanTu && w.Xe.GiaBan <= denGiaBan).OrderByDescending(w => w.NgayDang).ToList();
            }
            else if (namSanXuat == 2000)
            {
                listDeal = db.BanTins.Where(w => w.Xe.HangXe == hangXe && w.Xe.NamSanXuat >= 1992 && w.Xe.NamSanXuat <= namSanXuat && w.Xe.TinhTrang == tinhTrang
                    && w.Xe.DonVi == donVi && w.Xe.GiaBan >= giaBanTu && w.Xe.GiaBan <= denGiaBan).OrderByDescending(w => w.NgayDang).ToList();
            }
            else if (namSanXuat == 2005)
            {
                listDeal = db.BanTins.Where(w => w.Xe.HangXe == hangXe && w.Xe.NamSanXuat >= 2001 && w.Xe.NamSanXuat <= namSanXuat && w.Xe.TinhTrang == tinhTrang
                    && w.Xe.DonVi == donVi && w.Xe.GiaBan >= giaBanTu && w.Xe.GiaBan <= denGiaBan).OrderByDescending(w => w.NgayDang).ToList();
            }
            else if (namSanXuat == 2010)
            {
                listDeal = db.BanTins.Where(w => w.Xe.HangXe == hangXe && w.Xe.NamSanXuat >= 2006 && w.Xe.NamSanXuat <= namSanXuat && w.Xe.TinhTrang == tinhTrang
                    && w.Xe.DonVi == donVi && w.Xe.GiaBan >= giaBanTu && w.Xe.GiaBan <= denGiaBan).OrderByDescending(w => w.NgayDang).ToList();
            }
            else
            {
                listDeal = db.BanTins.Where(w => w.Xe.HangXe == hangXe && w.Xe.NamSanXuat >= 2011 && w.Xe.TinhTrang == tinhTrang
                    && w.Xe.DonVi == donVi && w.Xe.GiaBan >= giaBanTu && w.Xe.GiaBan <= denGiaBan).OrderByDescending(w => w.NgayDang).ToList();
            }
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            if (listDeal.Count > 0)
            {
                ViewBag.Flag = true;
                ViewBag.Notification = "Tìm thấy " + listDeal.Count + " kết quả.";
                return View(listDeal.OrderBy(o => o.TieuDe).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Flag = false;
            return View();
        }
        [HttpGet]
        public ActionResult SearchResult(int? page, string fKW)
        {
            ViewBag.KeyWord = fKW;
            List<BanTin> listDeal = db.BanTins.Where(w => w.TieuDe.Contains(fKW)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            if (listDeal.Count > 0)
            {
                ViewBag.Flag = true;
                ViewBag.Notification = "Tìm thấy " + listDeal.Count + " kết quả.";
                return View(listDeal.OrderBy(o => o.TieuDe).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Flag = false;
            return View();
        }
    }
}