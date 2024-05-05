﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTW2024.Entities
{
    public class SanPham
    {
        [Key]
        [StringLength(10)]
        public string MaSP { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        public string TenSP { get; set; }

        public decimal? DonGia { get; set; }

        [NotMapped]
        public bool IsSoLuongLonHon0
        {
            get { return SoLuong > 0; }
        }
        public int SoLuong { get; set; }

        public ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public ICollection<ChiTietHD> ChiTietHDs { get; set; }
    }
}
