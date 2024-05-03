using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTW2024.Entities
{
    public class ChiTietPhieuNhap
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaPhieu { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string MaSP { get; set; }

        public HoaDonNhapHang HoaDonNhapHang { get; set; }
        public SanPham SanPham { get; set; }

        public int SoLuong { get; set; }

        public decimal? DonGia { get; set; }
    }
}
