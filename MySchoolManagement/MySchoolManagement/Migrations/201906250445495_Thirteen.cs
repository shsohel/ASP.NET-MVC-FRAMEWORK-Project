namespace MySchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thirteen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "ConfirmPhoneNumber", c => c.String());
            AddColumn("dbo.Teachers", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "TeacherName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Teachers", "CellPhoneNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "CellPhoneNo", c => c.String());
            AlterColumn("dbo.Teachers", "TeacherName", c => c.String());
            DropColumn("dbo.Teachers", "EmailAddress");
            DropColumn("dbo.Teachers", "ConfirmPhoneNumber");
        }
    }
}
