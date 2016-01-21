using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CarAmbition.Models
{
    public class LoginModelView
    {
    }
    public class UserLogin
    {
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tài Khoản")]
        public string TaiKhoan { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }
    }
    public class PhanQuyenProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string tendangnhap)
        {
            using (CarEntities db = new CarEntities())
            {
                var taikhoan = db.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == tendangnhap);
                if (taikhoan == null)
                {
                    return null;
                }
                else
                {
                    string[] listQuyen = taikhoan.PhanQuyens.Select(s => s.Quyen.TenQuyen).ToArray();
                    return listQuyen;
                }
            }
        }
        public override string ApplicationName { get; set; }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames) { }
        public override void CreateRole(string roleName) { }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) { return false; }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch) { return null; }
        public override string[] GetAllRoles() { return null; }
        public override string[] GetUsersInRole(string roleName) { return null; }
        public override bool IsUserInRole(string username, string roleName) { return false; }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) { }
        public override bool RoleExists(string roleName) { return false; }
    }
}