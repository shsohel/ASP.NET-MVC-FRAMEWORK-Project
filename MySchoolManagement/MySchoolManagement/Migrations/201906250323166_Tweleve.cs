namespace MySchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tweleve : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Examresults",
                c => new
                    {
                        ExamresultID = c.Int(nullable: false, identity: true),
                        ExamType = c.String(),
                        StudentID = c.Int(nullable: false),
                        MarkInBangla = c.Int(nullable: false),
                        MarkInEnglish = c.Int(nullable: false),
                        MarkInMath = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamresultID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        MyClassID = c.Int(nullable: false),
                        RoleNo = c.Int(nullable: false),
                        BirthofDate = c.DateTime(nullable: false),
                        CellPhoneNo = c.String(),
                        Address = c.String(),
                        PicUrl = c.String(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Mclasses", t => t.MyClassID, cascadeDelete: true)
                .Index(t => t.MyClassID);
            
            CreateTable(
                "dbo.Mclasses",
                c => new
                    {
                        MyClassID = c.Int(nullable: false, identity: true),
                        MyClassName = c.String(),
                        SubjectID = c.Int(nullable: false),
                        SectionID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MyClassID)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.SectionID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionID = c.Int(nullable: false, identity: true),
                        ShiftName = c.String(),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.SectionID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        BirthofDate = c.DateTime(nullable: false),
                        CellPhoneNo = c.String(),
                        Address = c.String(),
                        PicUrl = c.String(),
                    })
                .PrimaryKey(t => t.TeacherID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ClassScheduleID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassScheduleID)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Schedules", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Mclasses", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Mclasses", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Students", "MyClassID", "dbo.Mclasses");
            DropForeignKey("dbo.Mclasses", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.Examresults", "StudentID", "dbo.Students");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Schedules", new[] { "TeacherID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Mclasses", new[] { "TeacherID" });
            DropIndex("dbo.Mclasses", new[] { "SectionID" });
            DropIndex("dbo.Mclasses", new[] { "SubjectID" });
            DropIndex("dbo.Students", new[] { "MyClassID" });
            DropIndex("dbo.Examresults", new[] { "StudentID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Schedules");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Sections");
            DropTable("dbo.Mclasses");
            DropTable("dbo.Students");
            DropTable("dbo.Examresults");
        }
    }
}
