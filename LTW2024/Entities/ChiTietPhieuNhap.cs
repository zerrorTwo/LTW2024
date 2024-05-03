using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTW2024.Entities
{
    public class ChiTietPhieuNhap
    {
        [StringLength(10)]
        public string MaPhieu { get; set; }
        public HoaDonNhapHang HoaDonNhapHang { get; set; }

        [StringLength(10)]
        public string MaSP { get; set; }
        public SanPham SanPham { get; set; }

        public int SoLuong { get; set; }

        public decimal? DonGia { get; set; }
    }
}
