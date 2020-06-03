namespace Restaurant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillNo = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Single(nullable: false),
                        StaffId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        OrderNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillNo)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderNo, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.StaffId)
                .Index(t => t.CustomerId)
                .Index(t => t.OrderNo);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Int(nullable: false),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderNo = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Num_Of_Items = c.Int(nullable: false),
                        StaffId = c.Int(),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderNo)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Staffs", t => t.StaffId)
                .Index(t => t.StaffId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        MealID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Size = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MealID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        Role = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        phone = c.Int(nullable: false),
                        Salary = c.Single(nullable: false),
                        Daysoff = c.String(),
                        JoinedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId);
            
            CreateTable(
                "dbo.MealOrders",
                c => new
                    {
                        Meal_MealID = c.Int(nullable: false),
                        Order_OrderNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meal_MealID, t.Order_OrderNo })
                .ForeignKey("dbo.Meals", t => t.Meal_MealID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderNo, cascadeDelete: true)
                .Index(t => t.Meal_MealID)
                .Index(t => t.Order_OrderNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Bills", "OrderNo", "dbo.Orders");
            DropForeignKey("dbo.Bills", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.MealOrders", "Order_OrderNo", "dbo.Orders");
            DropForeignKey("dbo.MealOrders", "Meal_MealID", "dbo.Meals");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.MealOrders", new[] { "Order_OrderNo" });
            DropIndex("dbo.MealOrders", new[] { "Meal_MealID" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "StaffId" });
            DropIndex("dbo.Bills", new[] { "OrderNo" });
            DropIndex("dbo.Bills", new[] { "CustomerId" });
            DropIndex("dbo.Bills", new[] { "StaffId" });
            DropTable("dbo.MealOrders");
            DropTable("dbo.Staffs");
            DropTable("dbo.Meals");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Bills");
        }
    }
}
