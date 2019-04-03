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

            //context.Departments.AddOrUpdate(m => m.DepartmentID,
            //    new Department
            //    {
            //        DName = "Admissions",
            //        Location = "North District"
            //    },
            //    new Department
            //    {
            //        DName = "Retail",
            //        Location = "South District"
            //    },
            //    new Department
            //    {
            //        DName = "Operations",
            //        Location = "Central District"
            //    },
            //    new Department {
            //        DName = "Public Relations",
            //        Location = "East District"
            //    },
            //    new Department
            //    {
            //        DName = "IT",
            //        Location = "West District"
            //    });

            //context.ParkEmployees.AddOrUpdate(m => m.EmployeeID,
            //    new ParkEmployee
            //    {
            //        FirstName = "Brandon",
            //        LastName = "Jimenez",
            //        MiddleName = "Tyler",
            //        StreetAddress = "1234 Battleship St.",
            //        State = "Tx",
            //        City = "Houston",
            //        PhoneNumber = "888-888-8888",
            //        ZipCode = "77412",
            //        DateOfBirth = new DateTime(1998, 07, 31),
            //        JobTitle = "PR Manager",
            //        Sex = "M",
            //        Department = context.Departments.Single(x => x.DName == "Public Relations")
            //    },


            //new ParkEmployee
            //{
            //    FirstName = "Yonathan",
            //    LastName = "Fondja",
            //    MiddleName = "Kibru",
            //    StreetAddress = "1234 Cougar St.",
            //    State = "Tx",
            //    City = "Houston",
            //    PhoneNumber = "888-888-8888",
            //    ZipCode = "77412",
            //    DateOfBirth = new DateTime(1998, 12, 31),
            //    JobTitle = "Retail Manager",
            //    Sex = "M",
            //    Department = context.Departments.Single(x => x.DName == "Retail")
            //}


            //new ParkEmployee
            //{
            //    FirstName = "Jacky",
            //    LastName = "Chan",
            //    MiddleName = null,
            //    StreetAddress = "1234 Dell St.",
            //    State = "Tx",
            //    City = "Houston",
            //    PhoneNumber = "888-888-8888",
            //    ZipCode = "77412",
            //    DateOfBirth = new DateTime(1997, 04, 09),
            //    JobTitle = "IT Manager",
            //    Sex = "M",
            //    Department = context.Departments.Single(x => x.DName == "IT")
            //}
            //);

            //context.MANAGED_BY.AddOrUpdate(m => m.DepartmentID,
            //    new MANAGED_BY
            //    {
            //        Department = context.Departments.Single(x => x.DName == "Public Relations"),
            //        ParkEmployee = context.ParkEmployees.Single(x => x.FirstName == "Brandon" && x.LastName == "Jimenez")
            //    },
            //    new MANAGED_BY
            //    {
            //        Department = context.Departments.Single(x => x.DName == "IT"),
            //        ParkEmployee = context.ParkEmployees.Single(x => x.FirstName == "Jacky" && x.LastName == "Chan")
            //    },
            //    new MANAGED_BY
            //    {
            //        Department = context.Departments.Single(x => x.DName == "Retail"),
            //        ParkEmployee = context.ParkEmployees.Single(x => x.FirstName == "Yonathan" && x.LastName == "Fondja")
            //    }
            //    );

            //context.EmployeeLogins.AddOrUpdate(m => m.LoginEmail,
            //    new EmployeeLogin {
            //        LoginEmail = "le.toanjames@gmail.com",
            //        Pswd = "1qaz!QAZ",
            //        ParkEmployee = context.ParkEmployees.Single(x => x.FirstName == "James")
            //    },
            //    new EmployeeLogin
            //    {
            //        LoginEmail = "yonathankibru@gmail.com",
            //        Pswd = "1qaz!QAZ",
            //        ParkEmployee = context.ParkEmployees.Single(x => x.FirstName == "Yonathan")
            //    }, new EmployeeLogin
            //    {
            //        LoginEmail = "bjimene1998@gmail.com",
            //        Pswd = "1qaz!QAZ",
            //        ParkEmployee = context.ParkEmployees.Single(x => x.FirstName == "Brandon")
            //    }, new EmployeeLogin
            //    {
            //        LoginEmail = "q812444566@gmail.com",
            //        Pswd = "1qaz!QAZ",
            //        ParkEmployee = context.ParkEmployees.Single(x => x.FirstName == "Jacky")
            //    });
        }
    }
}
