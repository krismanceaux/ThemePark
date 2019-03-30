namespace ThemePark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroppedSalaryFromEmployeeTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("ThemePark2.ParkEmployee", "Salary");
        }
        
        public override void Down()
        {
            AddColumn("ThemePark2.ParkEmployee", "Salary", c => c.Long());
        }
    }
}
