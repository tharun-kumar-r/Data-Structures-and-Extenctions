namespace Dode_First_EF_MIgrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDED_NEW_COL_STS_IN_DEPT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Sts", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "Sts");
        }
    }
}
