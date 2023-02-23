namespace ShoppingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        Title = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemArtUrl = c.String(),
                        Category_cat_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Categories", t => t.Category_cat_id)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.Category_cat_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        cat_id = c.String(nullable: false, maxLength: 128),
                        cat_name = c.String(),
                        cat_desc = c.String(),
                    })
                .PrimaryKey(t => t.cat_id);
            
            CreateTable(
                "dbo.OrderDets",
                c => new
                    {
                        OrderDetID = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Uniteprice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetID)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UsesrName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.OrderDets", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDets", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "Category_cat_id", "dbo.Categories");
            DropIndex("dbo.OrderDets", new[] { "ItemId" });
            DropIndex("dbo.OrderDets", new[] { "OrderId" });
            DropIndex("dbo.Items", new[] { "Category_cat_id" });
            DropIndex("dbo.Items", new[] { "OwnerId" });
            DropIndex("dbo.Carts", new[] { "ItemId" });
            DropTable("dbo.Owners");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDets");
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
            DropTable("dbo.Carts");
        }
    }
}
