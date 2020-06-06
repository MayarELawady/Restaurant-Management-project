namespace Restaurant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewOrderProberity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ORDERTest", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ORDERTest");
        }
    }
}
