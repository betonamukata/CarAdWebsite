using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace CarAmbition.Models
{
    [MetadataTypeAttribute(typeof(NguoiDungMetadata))]
    public partial class NguoiDung
    {
        internal sealed class NguoiDungMetadata
        {
            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Tài khoản")]
            public string TaiKhoan { get; set; }

            [DataType(DataType.Password)]
            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Mật khẩu")]
            public string MatKhau { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Họ tên")]
            public string HoTen { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^([0-9]{10,11})$", ErrorMessage = "{0} không đúng định dạng")]
            [Display(Name = "Điện thoại")]
            public string DienThoai { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Địa chỉ")]
            public string DiaChi { get; set; }

            [DataType(DataType.Password)]
            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Xác nhận mật khẩu")]
            [System.Web.Mvc.Compare("MatKhau", ErrorMessage = "Mật khẩu không trùng khớp")]
            public string XacNhanMatKhau { get; set; }
        }
    }
}