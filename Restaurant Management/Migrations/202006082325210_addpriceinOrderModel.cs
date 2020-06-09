namespace Restaurant_Management_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpriceinOrderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "price");
        }
    }
}
