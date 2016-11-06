namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product_Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        image = c.String(),
                        describe = c.String(),
                        detail = c.String(),
                        price = c.Long(nullable: false),
                        status = c.Byte(nullable: false),
                        extension = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.DetailOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        count = c.Int(nullable: false),
                        price = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        price = c.Long(nullable: false),
                        status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        url = c.String(),
                        name = c.String(),
                        extension = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permission_Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role_Id = c.Int(nullable: false),
                        Permission_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permissions", t => t.Permission_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Permission_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        permission = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User_Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 30),
                        password = c.String(nullable: false, maxLength: 50),
                        fullname = c.String(nullable: false, maxLength: 60),
                        birthday = c.DateTime(nullable: false),
                        sex = c.Boolean(nullable: false),
                        people_id = c.String(nullable: false, maxLength: 100),
                        address = c.String(nullable: false, maxLength: 150),
                        phone = c.String(nullable: false, maxLength: 12),
                        email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Role", "User_Id", "dbo.User");
            DropForeignKey("dbo.Products", "User_Id", "dbo.User");
            DropForeignKey("dbo.User_Role", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Permission_Role", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Permission_Role", "Permission_Id", "dbo.Permissions");
            DropForeignKey("dbo.Product_Category", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.DetailOrders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.DetailOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Product_Category", "Category_Id", "dbo.Categories");
            DropIndex("dbo.User_Role", new[] { "Role_Id" });
            DropIndex("dbo.User_Role", new[] { "User_Id" });
            DropIndex("dbo.Permission_Role", new[] { "Permission_Id" });
            DropIndex("dbo.Permission_Role", new[] { "Role_Id" });
            DropIndex("dbo.DetailOrders", new[] { "Product_Id" });
            DropIndex("dbo.DetailOrders", new[] { "Order_Id" });
            DropIndex("dbo.Products", new[] { "User_Id" });
            DropIndex("dbo.Product_Category", new[] { "Category_Id" });
            DropIndex("dbo.Product_Category", new[] { "Product_Id" });
            DropTable("dbo.User");
            DropTable("dbo.User_Role");
            DropTable("dbo.Roles");
            DropTable("dbo.Permission_Role");
            DropTable("dbo.Permissions");
            DropTable("dbo.Media");
            DropTable("dbo.Orders");
            DropTable("dbo.DetailOrders");
            DropTable("dbo.Products");
            DropTable("dbo.Product_Category");
            DropTable("dbo.Categories");
        }
    }
}
