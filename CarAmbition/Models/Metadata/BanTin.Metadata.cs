using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarAmbition.Models
{
    [MetadataTypeAttribute(typeof(BanTinMetadata))]
    public partial class BanTin
    {
        internal sealed class BanTinMetadata
        {
            [Display(Name = "Mã Bản Tin")]
            public int MaBanTin { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            //[StringLength(100)]
            [Display(Name = "Tiêu đề")]
            public string TieuDe { get; set; }

            //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
            //[Required(ErrorMessage = "{0} không được để trống")]
            //[StringLength(3000)]
            [Display(Name = "Nội dung")]
            public string NoiDung { get; set; }

            //[DataType(DataType.Date)]
            //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
            [Display(Name = "Ngày đăng")]
            public System.DateTime NgayDang { get; set; }

            [Display(Name = "Hình ảnh")]
            public string HinhAnh { get; set; }

            public Nullable<int> MaXe { get; set; }
            public string TaiKhoan { get; set; }
        }
    }
}