namespace ThemePark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateKeyInPERMITS : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE ThemePark.PERMITS drop constraint PK__PERMITS__69061479254B3484");
            //DropPrimaryKey("ThemePark.PERMITS");
            AlterColumn("ThemePark.PERMITS", "PTimeStamp", c => c.DateTime(nullable: false));
            AddPrimaryKey("ThemePark.PERMITS", new[] { "RideID", "TicketNumber", "PTimeStamp" });
        }
        
        public override void Down()
        {
            //DropPrimaryKey("ThemePark.PERMITS");
            //AlterColumn("ThemePark.PERMITS", "PTimeStamp", c => c.DateTime());
            //AddPrimaryKey("ThemePark.PERMITS", new[] { "RideID", "TicketNumber" });
        }
    }
}
