namespace ThemePark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTendedByKey : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("PK__TENDED_B__C215C0EB7B81EE2E");
            Sql("Alter table ThemePark.TENDED_BY drop constraint PK__TENDED_B__C215C0EB7B81EE2E");
            AddPrimaryKey("ThemePark.TENDED_BY", new[] { "RideID", "EmployeeID", "DateTended" });
        }
        
        public override void Down()
        {
           
        }
    }
}
