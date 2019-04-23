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








            ///////////////////////
            ///        Ticket
            ///////////////////////

            //// set prices per code
            //decimal[] prices = { (decimal)12.00, (decimal)8.00, (decimal)10.00, (decimal)10.00 };
            //// set codes per prices
            //int[] codes = { 1, 2, 3, 4 };
            //// start date
            //var date = new DateTime(2019, 1, 1);
            //int dateIncrement = 1;
            //var date2 = new DateTime(2019, 4, 13);
            ////var numDays = (DateTime.Now.Date - date).TotalDays;
            //var numDays = (date2 - date).TotalDays;
            //// for the next 10 days (replace 10 with numDays)
            //for (int i = 0; i < numDays; i++)
            //{
            //    Random rnd1 = new Random();
            //    int numTickets = rnd1.Next(125);
            //    // each day create a random number of tickets between 5-9
            //    for (int j = 0; j < numTickets; j++)
            //    {
            //        var newDate = date.AddDays(dateIncrement);

            //        Random rnd = new Random();
            //        int pos = rnd.Next(5 - 1);
            //        context.Tickets.AddOrUpdate(t => t.TicketNumber,

            //            new Ticket
            //            {
            //                Price = prices[pos],
            //                DateOfPurchase = newDate,
            //                TicketCode = codes[pos]
            //            });
            //    }

            //    // increment 1 day
            //    dateIncrement++;
            //}








            /////////////////////////////
            ///          ADMITTED_BY
            /////////////////////////////


            //var tickets = context.Tickets.ToList();
            //var employees = context.ParkEmployees.Where(e => e.DepartmentID == 100001).ToList();
            //var startDate = new DateTime(2019, 1, 1);
            //var endDate = new DateTime(2019, 4, 13);
            //var startDateIncrement = 1;
            ////var numberofdays = (DateTime.Now.Date - startDate).TotalDays;
            //var numberofdays = (endDate - startDate).TotalDays;
            //int currentTicketTracker = 0;

            //// for each day
            //for (int k = 0; k < numberofdays; k++)
            //{

            //    // generate a random number of tickets
            //    var rnd3 = new Random();
            //    int numTickets = rnd3.Next(75);

            //    // if the number + currentTicket number exposes us to an index out of range -> break
            //    if ((currentTicketTracker + numTickets) > (tickets.Count() - 1)) break;

            //    // for each ticket admitted this day starting from where we left off in the ticket list
            //    for (int l = currentTicketTracker; l < (currentTicketTracker + numTickets); l++)
            //    {
            //        var newStartDate = startDate.AddDays(startDateIncrement);

            //        // get a random employee
            //        var rnd2 = new Random();
            //        var empNum = rnd2.Next(employees.Count());
            //        var currentEmployee = employees[empNum];

            //        // add new admitted_by record
            //        context.ADMITTED_BY.AddOrUpdate(x => x.TicketID,
            //            new ADMITTED_BY
            //            {
            //                EmployeeID = currentEmployee.EmployeeID,
            //                TicketID = tickets[l].TicketNumber,
            //                AdmissionsDate = newStartDate
            //            });

            //    }
            //    // keep track of which tickets we just admitted
            //    currentTicketTracker += numTickets;
            //    // increment day
            //    startDateIncrement++;
            //}








            ////////////////////////////////////
            ///        PERMITS
            ////////////////////////////////////

            //// get all rides
            //var rides = context.Rides.ToList();

            //var timestamp = new DateTime(2019, 1, 3);
            //TimeSpan d = DateTime.Now.TimeOfDay;
            //var timeStampDayIncrement = 1;
            //var secondIncrement = 1;
            //timestamp += d;
            //var stopDate = new DateTime(2019, 4, 13);
            ////var numDays = (DateTime.Now.Date - timestamp).TotalDays;
            //var numDays = (stopDate - timestamp).TotalDays;

            //// on each day
            //for (int i = 0; i < numDays; i++)
            //{
            //    var newTimeStamp = timestamp.AddDays(timeStampDayIncrement).AddSeconds(secondIncrement);

            //    // get all tickets admimtted on this day
            //    var admitsToday = context.ADMITTED_BY.Where(x => x.AdmissionsDate == newTimeStamp.Date).ToList();
            //    var rnd = new Random();

            //    //random number for total times every ride was ridden that day
            //    var totalRides = rnd.Next(25, 60);
            //    if (admitsToday.Count() > 0)
            //    {

            //        //for each time ridden this day
            //        for (int j = 0; j < totalRides; j++)
            //        {
            //            // for each ride that day
            //            var randRideIndex = rnd.Next(0, 10);

            //            var rnd1 = new Random();
            //            var randomTicket = rnd1.Next(admitsToday.Count() - 1);
            //            var newNewTimeStamp = newTimeStamp.AddSeconds(secondIncrement);
            //            // generate new record with unique timestamp, random ticket, and current ride
            //            context.PERMITS.AddOrUpdate(
            //                new PERMIT
            //                {
            //                    RideID = rides[randRideIndex].RideID,
            //                    TicketNumber = admitsToday[randomTicket].TicketID,
            //                    PTimeStamp = newNewTimeStamp
            //                });
            //            // change time
            //            secondIncrement += 1;


            //        }
            //    }
            //    //change day
            //    timeStampDayIncrement++;

            //}





            ///////////////////////
            ///        TENDED_BY
            ///////////////////////

            //var rides = context.Rides.ToList();
            //var employees = context.ParkEmployees.Where(x => x.DepartmentID == 100003 && x.EmployeeID != 100001).ToList();
            //var startDate = new DateTime(2019, 1, 1);
            //var startDateIncrement = 1;
            //var numberofdays = (DateTime.Now.Date - startDate).TotalDays;

            //for(int i = 0; i < numberofdays; i++)
            //{
            //    var newStartDate = startDate.AddDays(startDateIncrement);

            //    for(int j = 0; j < rides.Count(); j++)
            //    {
            //        context.TENDED_BY.AddOrUpdate(

            //            new TENDED_BY
            //            {
            //                RideID = rides[j].RideID,
            //                EmployeeID = employees[j].EmployeeID,
            //                DateTended = newStartDate.Date

            //            });
            //    }

            //    startDateIncrement++;
            //}







            ///////////////////////////
            //       SOLD BY
            ///////////////////////////


            //var employees = context.ParkEmployees.Where(x => x.DepartmentID == 100002 && x.EmployeeID != 100002).ToList();
            //var items = context.Concessions.ToList();

            //var timestamp = new DateTime(2019, 1, 3);
            //TimeSpan d = DateTime.Now.TimeOfDay;
            //var timeStampDayIncrement = 1;
            //var secondIncrement = 1;
            //timestamp += d;
            //var numDays = (DateTime.Now.Date - timestamp).TotalDays;

            //// on each day
            //for (int i = 0; i < numDays; i++)
            //{
            //    var newTimeStamp = timestamp.AddDays(timeStampDayIncrement).AddSeconds(secondIncrement);
            //    var rnd = new Random();
            //    var numSales = rnd.Next(25, 75);
            //    for(int j = 0; j < numSales; j++)
            //    {
            //        var newNewTimeStamp = newTimeStamp.AddSeconds(secondIncrement);
            //        var randItem = rnd.Next(items.Count() - 1);
            //        var randEmp = rnd.Next(employees.Count() - 1);

            //        context.SOLD_BY.AddOrUpdate(
            //            new SOLD_BY {

            //                ItemName = items[randItem].ItemName,
            //                EmployeeID = employees[randEmp].EmployeeID,
            //                DateSold = newNewTimeStamp

            //            });
            //        secondIncrement += 1;
            //    }
            //    timeStampDayIncrement++;
            //}


        }
    }
}
