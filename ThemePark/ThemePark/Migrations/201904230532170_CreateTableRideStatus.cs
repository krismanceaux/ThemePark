namespace ThemePark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableRideStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ThemePark.RideStatus",
                c => new
                    {
                        RideStatus = c.Int(nullable: false, identity: true),
                        StatusDescription = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RideStatus);
            
            AddColumn("ThemePark.Ride", "RideStatus", c => c.Int());
            CreateIndex("ThemePark.Ride", "RideStatus");
            AddForeignKey("ThemePark.Ride", "RideStatus", "ThemePark.RideStatus", "RideStatus");
        }
        
        public override void Down()
        {
            DropForeignKey("ThemePark.Ride", "RideStatus", "ThemePark.RideStatus");
            DropIndex("ThemePark.Ride", new[] { "RideStatus" });
            DropColumn("ThemePark.Ride", "RideStatus");
            DropTable("ThemePark.RideStatus");
        }
    }
}
