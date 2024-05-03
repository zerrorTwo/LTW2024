using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTW2024.Entities
{
    public class TaiKhoan
    {
        [Key]
        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(10)]
        public string MaNV { get; set; }
        public NhanVien NhanVien { get; set; }

        [StringLength(20)]
        public string Role { get; set; }
    }
}
