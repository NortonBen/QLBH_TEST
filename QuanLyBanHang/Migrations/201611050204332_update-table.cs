namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Media", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Media", "size", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Media", "size");
            DropColumn("dbo.Media", "date");
            DropColumn("dbo.Products", "date");
        }
    }
}
