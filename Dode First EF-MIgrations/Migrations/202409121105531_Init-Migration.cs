namespace Dode_First_EF_MIgrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DId = c.Int(nullable: false, identity: true),
                        DName = c.String(),
                    })
                .PrimaryKey(t => t.DId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        DId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DId, cascadeDelete: true)
                .Index(t => t.DId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
