using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTW2024.Entities
{
    public class KhachHang
    {
        [Key]
        [StringLength(6)]
        public string MaKH { get; set; }

        [StringLength(30)]
        public string TenKH { get; set; }

        [StringLength(15)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Số điện thoại chỉ được chứa các ký tự số.")]
        public string SoDT { get; set; }

        public ICollection<HoaDonBanHang> HoaDonBanHangs { get; set; }
    }
}
