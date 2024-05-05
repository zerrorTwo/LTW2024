namespace LTW2024.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrations2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SanPhams", "TenSP", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.SanPhams", new[] { "TenSP" });
        }
    }
}
