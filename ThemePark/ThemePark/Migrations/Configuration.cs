namespace ThemePark.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ThemePark.TPContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ThemePark.TPContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            //context.MaintCodes.AddOrUpdate(m => m.MaintCode1,
            //    new MaintCode
            //    {
            //        MaintCode1 = 2,
            //        MaintType = "Scheduled"

            //    },
            //    new MaintCode
            //    {
            //        MaintCode1 = 3,
            //        MaintType = "Unscheduled"
            //    },
            //    new MaintCode
            //    {
            //        MaintCode1 = 4,
            //        MaintType = "Emergency"
            //    });


            //context.Maintenances.AddOrUpdate(m => m.MaintenanceID,
            //    new Maintenance
            //    {
            //        MaintDescription = "Periodic 30 day inspection",
            //        DateAdded = new DateTime(2019, 04, 02),
            //        MaintCode1 = new MaintCode { MaintCode1 = 1, MaintType = "Periodic"},
            //        Ride = new Ride { RideName = "Texas Cyclone", RideDiscription = "Wooden Rollercoaster", RideLocation = "West District", RideCapacity = 35 },

            //    });

            //context.Maintenances.AddOrUpdate(m => m.MaintenanceID,
            //    new Maintenance
            //    {
            //        MaintDescription = "Periodic 30 day inspection",
            //        DateAdded = new DateTime(2019, 04, 02),
            //        MaintCode1 = context.MaintCodes.Single(x => x.MaintCode1 == 1),
            //        Ride = context.Rides.Single(x => x.RideName == "Texas Cyclone"),

            //    });

            //context.PERFORMED_BY.AddOrUpdate(m => m.MaintenanceID,
            //    new PERFORMED_BY
            //    {
            //       ParkEmployee = context.ParkEmployees.Single(x => x.FirstName == "Kristopher"),
            //       Maintenance = context.Maintenances.Single(x=>x.MaintenanceID == 100001),
            //       ManHours = 2
            //    });




        }
    }
}
