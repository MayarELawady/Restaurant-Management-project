namespace Restaurant_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatatbase_after_constrains : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Staffs", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staffs", "Password", c => c.String());
            AlterColumn("dbo.Staffs", "UserName", c => c.String());
        }
    }
}
