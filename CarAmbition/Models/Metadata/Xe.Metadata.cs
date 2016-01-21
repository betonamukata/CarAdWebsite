using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarAmbition.Models
{
    [MetadataTypeAttribute(typeof(XeMetadata))]
    public partial class Xe
    {
        internal sealed class XeMetadata
        {
            [Display(Name = "Mã xe")]
            public int MaXe { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            //[StringLength(20)]
            [Display(Name = "Hãng xe")]
            public string HangXe { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            //[StringLength(20)]
            [Display(Name = "Loại xe")]
            public string LoaiXe { get; set; }

            //[RegularExpression(@"^\d+$")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Năm sản xuất")]
            public short NamSanXuat { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[StringLength(20)]
            [Display(Name = "Phiên bản")]
            public string PhienBan { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            //[StringLength(20)]
            [Display(Name = "Xuất xứ")]
            public string XuatXu { get; set; }

            [Display(Name = "Tình trạng")]
            public Nullable<bool> TinhTrang { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[StringLength(20)]
            [Display(Name = "Màu ngoại thất")]
            public string MauNgoaiThat { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[StringLength(20)]
            [Display(Name = "Màu nội thất")]
            public string MauNoiThat { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[StringLength(20)]
            [Display(Name = "Dáng xe")]
            public string DangXe { get; set; }

            //[RegularExpression(@"^\d+$")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Số Km đã đi")]
            public short SoKm { get; set; }

            //[RegularExpression(@"^\d+$")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Giá bán")]
            public short GiaBan { get; set; }

            [Display(Name = "Đơn vị")]
            public Nullable<bool> DonVi { get; set; }

            //[RegularExpression(@"^\d+$")]
            [Display(Name = "Số cửa")]
            public Nullable<short> SoCua { get; set; }

            //[RegularExpression(@"^\d+$")]
            [Display(Name = "Số chỗ ngồi")]
            public Nullable<short> SoCho { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[StringLength(20)]
            [Display(Name = "Hộp số")]
            public string HopSo { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[StringLength(30)]
            [Display(Name = "Dẫn động")]
            public string DanDong { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[StringLength(20)]
            [Display(Name = "Nhiên liệu")]
            public string NhienLieu { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[StringLength(20)]
            [Display(Name = "Mức tiêu thụ")]
            public string MucTieuThu { get; set; }
        }
    }
}