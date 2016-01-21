using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarAmbition.Models;
using System.Web.Security;

namespace CarAmbition.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        CarEntities db = new CarEntities();

        [HttpGet]
        public ActionResult Register(string returnUrl)
        {
            if (User.Identity.Name != "")
            {
                NguoiDung account = db.NguoiDungs.Single(x => x.TaiKhoan.Equals(User.Identity.Name));
                if (account != null)
                {
                    return RedirectToAction("Home", "Home");
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(NguoiDung nd)
        {
            if (ModelState.IsValid)
            {
                var checkAccount = db.NguoiDungs.Any(a => a.TaiKhoan == nd.TaiKhoan);
                if (!checkAccount)
                {
                    db.NguoiDungs.Add(nd);
                    db.SaveChanges();
                    db.Database.ExecuteSqlCommand("INSERT INTO PHANQUYEN(MAQUYEN, TAIKHOAN) VALUES (3,{0})", nd.TaiKhoan);
                    Session["Account"] = nd.TaiKhoan;
                    TempData["User"] = nd.TaiKhoan;
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("","Tài khoản đã có trong hệ thống");
                    return View("Register");
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.Name != "")
            {
                NguoiDung account = db.NguoiDungs.Single(x => x.TaiKhoan.Equals(User.Identity.Name));
                if (account != null)
                {
                    return RedirectToAction("Home", "Home");
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var checkLogin = db.NguoiDungs.Any(s => s.TaiKhoan == user.TaiKhoan && s.MatKhau == user.MatKhau);
                if (checkLogin)
                {
                    FormsAuthentication.SetAuthCookie(user.TaiKhoan, false);
                    Session["Account"] = user.TaiKhoan;
                    NguoiDung role = db.NguoiDungs.SingleOrDefault(s => s.TaiKhoan == user.TaiKhoan);
                    if (role.PhanQuyens.Select(s => s.Quyen.TenQuyen).First().ToString() == "admin")
                        Session["Role"] = "admin";
                    else
                        Session["Role"] = "user";
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
                    return View("Login", user);
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["Account"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "Home");
        }
    }
}