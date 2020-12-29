namespace EMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfo", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Department", "ParentId", "dbo.Department");
            DropIndex("dbo.UserInfo", new[] { "DepartmentId" });
            DropIndex("dbo.Department", new[] { "ParentId" });
            DropTable("dbo.UserInfo");
            DropTable("dbo.Department");
        }
    }
}
