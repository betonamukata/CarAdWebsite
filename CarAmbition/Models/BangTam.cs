﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarAmbition.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class BangTam
    {
        public BangTam()
        {
            this.HinhTams = new HashSet<HinhTam>();
        }
    
        public int MaTam { get; set; }
        public string HangXe { get; set; }
        public string LoaiXe { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Năm sản xuất")]
        public short NamSanXuat { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Phiên bản")]
        public string PhienBan { get; set; }
        public string XuatXu { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
        public string MauNoiThat { get; set; }
        public string MauNgoaiThat { get; set; }
        public string DangXe { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Số KM đã đi")]
        public short SoKm { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Giá bán")]
        public short GiaBan { get; set; }
        public Nullable<bool> DonVi { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Số cửa")]
        public Nullable<short> SoCua { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Số chỗ")]
        public Nullable<short> SoCho { get; set; }
        public string HopSo { get; set; }
        public string DanDong { get; set; }
        public string NhienLieu { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Mức tiêu thụ")]
        public Nullable<short> MucTieuThu { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        public System.DateTime NgayDang { get; set; }
        public string TaiKhoan { get; set; }
    
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual ICollection<HinhTam> HinhTams { get; set; }
    }
}
