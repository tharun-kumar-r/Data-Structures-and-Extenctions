namespace Dode_First_EF_MIgrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Salary_COL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Salary", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Salary");
        }
    }
}
