namespace MySchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourteen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "TeacherName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "TeacherName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
