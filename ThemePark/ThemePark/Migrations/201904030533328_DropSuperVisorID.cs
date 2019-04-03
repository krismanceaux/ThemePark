namespace ThemePark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropSuperVisorID : DbMigration
    {
        public override void Up()
        {
            DropColumn("ThemePark.Maintenance", "SupervisorID");
        }
        
        public override void Down()
        {
            AddColumn("ThemePark.Maintenance", "SupervisorID", c => c.Long());
        }
    }
}
