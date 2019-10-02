namespace MySchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fifteen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mclasses", "MyClassName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mclasses", "MyClassName", c => c.String());
        }
    }
}
