namespace MySchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sixteeen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Examresults", "ExamType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Examresults", "ExamType", c => c.String());
        }
    }
}
