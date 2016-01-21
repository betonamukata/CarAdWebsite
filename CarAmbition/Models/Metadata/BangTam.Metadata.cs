using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarAmbition.Models
{
    [MetadataTypeAttribute(typeof(BangTamMetadata))]
    public partial class BangTam
    {
        internal sealed class BangTamMetadata
        {
            [Display(Name = "Mã Tạm")]
            public int MaTam { get; set; }

            //[Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Hãng Xe")]
            public string HangXe { get; set; }

            //[Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Loại Xe")]
            public string LoaiXe { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            //[RegularExpression(@"^([0-9]{4})$", ErrorMessage = "{0} không đúng định dạng")]
            [Display(Name = "Năm Sản Xuất")]
            public short NamSanXuat { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Phiên Bản")]
            public string PhienBan { get; set; }

            //[Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Xuất Xứ")]
            public string XuatXu { get; set; }

            [Display(Name = "Tình Trạng")]
            public Nullable<bool> TinhTrang { get; set; }

            [Display(Name = "Màu Ngoại Thất")]
            public string MauNgoaiThat { get; set; }

            [Display(Name = "Màu Nội Thất")]
            public string MauNoiThat { get; set; }

            [Display(Name = "Dáng Xe")]
            public string DangXe { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            //[RegularExpression(@"^([0-9])$", ErrorMessage = "{0} không đúng định dạng")]
            [Display(Name = "Số KM đã đi")]
            public short SoKm { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            //[RegularExpression(@"^([0-9])$", ErrorMessage = "{0} không đúng định dạng")]
            [Display(Name = "Giá Bán")]
            public short GiaBan { get; set; }

            [Display(Name = "Đơn Vị")]
            public Nullable<bool> DonVi { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Số Cửa")]
            public Nullable<short> SoCua { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Số Chỗ")]
            public Nullable<short> SoCho { get; set; }

            [Display(Name = "Hộp Số")]
            public string HopSo { get; set; }

            [Display(Name = "Dẫn Động")]
            public string DanDong { get; set; }

            [Display(Name = "Nhiên Liệu")]
            public string NhienLieu { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Mức Tiêu Thụ")]
            public string MucTieuThu { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Tiêu Đề")]
            public string TieuDe { get; set; }

            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Nội dung")]
            public string NoiDung { get; set; }

            [Display(Name = "Ngày Đăng")]
            public System.DateTime NgayDang { get; set; }

            [Display(Name = "Tài khoản")]
            public string TaiKhoan { get; set; }
        }
    }
}