using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarAmbition.Models
{
    [MetadataTypeAttribute(typeof(ChiTietHinhMetadata))]
    public partial class ChiTietHinh
    {
        internal sealed class ChiTietHinhMetadata
        {
            [Display(Name = "Mã CT")]
            public int MaCT { get; set; }

            [Display(Name = "Hình To")]
            public string HinhTo { get; set; }

            [Display(Name = "Hình Nhỏ")]
            public string HinhNho { get; set; }

            [Display(Name = "Mã Xe")]
            public Nullable<int> MaXe { get; set; }
        }
    }
}