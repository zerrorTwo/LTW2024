namespace LTW2024.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrations1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TaiKhoans", new[] { "MaNV" });
            CreateIndex("dbo.TaiKhoans", "MaNV", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.TaiKhoans", new[] { "MaNV" });
            CreateIndex("dbo.TaiKhoans", "MaNV");
        }
    }
}
