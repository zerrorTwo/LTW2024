namespace LTW2024.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHDs",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 10),
                        MaSP = c.String(nullable: false, maxLength: 10),
                        SoLuongSP = c.Int(nullable: false),
                        DonGia = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.MaHD, t.MaSP })
                .ForeignKey("dbo.HoaDonBanHangs", t => t.MaHD)
                .ForeignKey("dbo.SanPhams", t => t.MaSP)
                .Index(t => t.MaHD)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.HoaDonBanHangs",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 10),
                        NgayDatHang = c.DateTime(nullable: false, storeType: "date"),
                        TongSoTien = c.Decimal(precision: 18, scale: 2),
                        MaNV = c.String(maxLength: 6),
                        MaKH = c.String(maxLength: 6),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.KhachHangs", t => t.MaKH)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .Index(t => t.MaNV)
                .Index(t => t.MaKH);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 6),
                        TenKH = c.String(maxLength: 30),
                        SoDT = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 6),
                        HoNV = c.String(maxLength: 10),
                        TenNV = c.String(maxLength: 20),
                        NgaySinh = c.DateTime(nullable: false, storeType: "date"),
                        GioiTinh = c.String(maxLength: 3),
                        SoDT = c.String(maxLength: 15),
                        DiaChi = c.String(maxLength: 50),
                        Luong = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaNV);
            
            CreateTable(
                "dbo.HoaDonNhapHangs",
                c => new
                    {
                        MaPhieu = c.String(nullable: false, maxLength: 10),
                        NgayNhap = c.DateTime(nullable: false, storeType: "date"),
                        TongTienDonNhap = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaNV = c.String(maxLength: 6),
                        MaNCC = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.MaPhieu)
                .ForeignKey("dbo.NhaCungCaps", t => t.MaNCC)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .Index(t => t.MaNV)
                .Index(t => t.MaNCC);
            
            CreateTable(
                "dbo.ChiTietPhieuNhaps",
                c => new
                    {
                        MaPhieu = c.String(nullable: false, maxLength: 10),
                        MaSP = c.String(nullable: false, maxLength: 10),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.MaPhieu, t.MaSP })
                .ForeignKey("dbo.HoaDonNhapHangs", t => t.MaPhieu)
                .ForeignKey("dbo.SanPhams", t => t.MaSP)
                .Index(t => t.MaPhieu)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        MaSP = c.String(nullable: false, maxLength: 10),
                        TenSP = c.String(maxLength: 50),
                        DonGia = c.Decimal(precision: 18, scale: 2),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSP);
            
            CreateTable(
                "dbo.NhaCungCaps",
                c => new
                    {
                        MaNCC = c.String(nullable: false, maxLength: 10),
                        TenNCC = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 50),
                        SoDT = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.MaNCC);
            
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(maxLength: 20),
                        MaNV = c.String(maxLength: 6),
                        Role = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.UserName)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .Index(t => t.MaNV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietHDs", "MaSP", "dbo.SanPhams");
            DropForeignKey("dbo.ChiTietHDs", "MaHD", "dbo.HoaDonBanHangs");
            DropForeignKey("dbo.HoaDonBanHangs", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.TaiKhoans", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.HoaDonNhapHangs", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.HoaDonNhapHangs", "MaNCC", "dbo.NhaCungCaps");
            DropForeignKey("dbo.ChiTietPhieuNhaps", "MaSP", "dbo.SanPhams");
            DropForeignKey("dbo.ChiTietPhieuNhaps", "MaPhieu", "dbo.HoaDonNhapHangs");
            DropForeignKey("dbo.HoaDonBanHangs", "MaKH", "dbo.KhachHangs");
            DropIndex("dbo.TaiKhoans", new[] { "MaNV" });
            DropIndex("dbo.ChiTietPhieuNhaps", new[] { "MaSP" });
            DropIndex("dbo.ChiTietPhieuNhaps", new[] { "MaPhieu" });
            DropIndex("dbo.HoaDonNhapHangs", new[] { "MaNCC" });
            DropIndex("dbo.HoaDonNhapHangs", new[] { "MaNV" });
            DropIndex("dbo.HoaDonBanHangs", new[] { "MaKH" });
            DropIndex("dbo.HoaDonBanHangs", new[] { "MaNV" });
            DropIndex("dbo.ChiTietHDs", new[] { "MaSP" });
            DropIndex("dbo.ChiTietHDs", new[] { "MaHD" });
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.NhaCungCaps");
            DropTable("dbo.SanPhams");
            DropTable("dbo.ChiTietPhieuNhaps");
            DropTable("dbo.HoaDonNhapHangs");
            DropTable("dbo.NhanViens");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.HoaDonBanHangs");
            DropTable("dbo.ChiTietHDs");
        }
    }
}
