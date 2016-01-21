using CarAmbition.Models;
using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarAmbition.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/
        CarEntities db = new CarEntities();

        public ActionResult PostDeal()
        {
            return View();
        }

        public ActionResult Submit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Submit(HinhTam pic, BangTam tam, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                if (files != null)
                {
                    tam.TaiKhoan = Session["Account"].ToString();
                    tam.NgayDang = DateTime.Now;
                    db.BangTams.Add(tam);
                    db.SaveChanges();
                    foreach (HttpPostedFileBase file in files)
                    {
                        var versions = new Dictionary<string, string>();
                        var path = Server.MapPath("~/Content/");
                        versions.Add("_thumb", "width=56&height=43&format=jpg");
                        versions.Add("", "width=960&height=527&format=jpg");
                        foreach (var suffix in versions.Keys)
                        {
                            file.InputStream.Seek(0, SeekOrigin.Begin);
                            ImageBuilder.Current.Build(
                                new ImageJob(
                                    file.InputStream,
                                    path + Path.GetFileNameWithoutExtension(file.FileName) + suffix,
                                    new Instructions(versions[suffix]),
                                    false,
                                    true));
                            if (suffix == "_thumb")
                                pic.HinhNho = Path.GetFileNameWithoutExtension(file.FileName) + suffix + ".jpg";
                            else
                                pic.HinhTo = Path.GetFileNameWithoutExtension(file.FileName) + suffix + ".jpg";
                        }
                        pic.MaTam = db.BangTams.OrderByDescending(o => o.MaTam).Select(s => s.MaTam).First();
                        db.HinhTams.Add(pic);
                        db.SaveChanges();
                    }
                }
            }
            return View();
        }
    }
}