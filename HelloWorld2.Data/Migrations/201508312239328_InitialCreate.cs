namespace HelloWorld2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        Author = c.String(nullable: false, maxLength: 15),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(nullable: false, maxLength: 150),
                        Email = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(nullable: false, maxLength: 4000),
                        Author = c.String(nullable: false, maxLength: 50),
                        Category = c.String(maxLength: 4000),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 4000),
                        Description = c.String(maxLength: 4000),
                        Progress = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Creations",
                c => new
                    {
                        CreationId = c.Int(nullable: false, identity: true),
                        CreationName = c.String(maxLength: 4000),
                        CreationDescription = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.CreationId);
            
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        DegreeId = c.String(nullable: false, maxLength: 4000),
                        DegreeType = c.String(maxLength: 4000),
                        DegreeMajor = c.String(maxLength: 4000),
                        DegreeName = c.String(maxLength: 4000),
                        DegreeDescription = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.DegreeId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        SchoolId = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(maxLength: 4000),
                        GPA = c.String(maxLength: 4000),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        Degrees = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.SchoolId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillDescription = c.String(maxLength: 4000),
                        SkillName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.SkillId);
            
            CreateTable(
                "dbo.Websites",
                c => new
                    {
                        WebsiteId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Description = c.String(maxLength: 4000),
                        Url = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.WebsiteId);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        WorkId = c.Int(nullable: false, identity: true),
                        WorkName = c.String(maxLength: 4000),
                        Description = c.String(maxLength: 4000),
                        WorkTitle = c.String(maxLength: 4000),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(),
                    })
                .PrimaryKey(t => t.WorkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "ProjectID" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropTable("dbo.Works");
            DropTable("dbo.Websites");
            DropTable("dbo.Skills");
            DropTable("dbo.Schools");
            DropTable("dbo.Degrees");
            DropTable("dbo.Creations");
            DropTable("dbo.Projects");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Abouts");
        }
    }
}
