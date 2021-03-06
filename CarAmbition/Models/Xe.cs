//------------------------------------------------------------------------------
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
    
    public partial class Xe
    {
        public Xe()
        {
            this.BanTins = new HashSet<BanTin>();
            this.ChiTietHinhs = new HashSet<ChiTietHinh>();
        }
    
        public int MaXe { get; set; }
        public string HangXe { get; set; }
        public string LoaiXe { get; set; }
        public short NamSanXuat { get; set; }
        public string PhienBan { get; set; }
        public string XuatXu { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
        public string MauNoiThat { get; set; }
        public string MauNgoaiThat { get; set; }
        public string DangXe { get; set; }
        public short SoKm { get; set; }
        public short GiaBan { get; set; }
        public Nullable<bool> DonVi { get; set; }
        public Nullable<short> SoCua { get; set; }
        public Nullable<short> SoCho { get; set; }
        public string HopSo { get; set; }
        public string DanDong { get; set; }
        public string NhienLieu { get; set; }
        public Nullable<short> MucTieuThu { get; set; }
    
        public virtual ICollection<BanTin> BanTins { get; set; }
        public virtual ICollection<ChiTietHinh> ChiTietHinhs { get; set; }
    }
}
