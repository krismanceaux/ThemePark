namespace ThemePark
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TPContext : DbContext
    {
        public TPContext()
            : base("name=TPContext")
        {
        }

        public virtual DbSet<ADMITTED_BY> ADMITTED_BY { get; set; }
        public virtual DbSet<Concession> Concessions { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DependentPassHolder> DependentPassHolders { get; set; }
        public virtual DbSet<EmployeeLogin> EmployeeLogins { get; set; }
        public virtual DbSet<MaintCode> MaintCodes { get; set; }
        public virtual DbSet<Maintenance> Maintenances { get; set; }
        public virtual DbSet<MANAGED_BY> MANAGED_BY { get; set; }
        public virtual DbSet<ParkEmployee> ParkEmployees { get; set; }
        public virtual DbSet<PERFORMED_BY> PERFORMED_BY { get; set; }
        public virtual DbSet<PERMIT> PERMITS { get; set; }
        public virtual DbSet<Ride> Rides { get; set; }
        public virtual DbSet<SeasonPassHolder> SeasonPassHolders { get; set; }
        public virtual DbSet<SOLD_BY> SOLD_BY { get; set; }
        public virtual DbSet<SPHLogin> SPHLogins { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketCode> TicketCodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concession>()
                .Property(e => e.ItemPrice)
                .HasPrecision(10, 4);

            modelBuilder.Entity<MaintCode>()
                .HasMany(e => e.Maintenances)
                .WithOptional(e => e.MaintCode1)
                .HasForeignKey(e => e.MaintCode);

            modelBuilder.Entity<ParkEmployee>()
                .Property(e => e.Sex)
                .IsFixedLength();

            modelBuilder.Entity<ParkEmployee>()
                .HasMany(e => e.EmployeeLogins)
                .WithOptional(e => e.ParkEmployee)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ParkEmployee>()
                .HasMany(e => e.Rides)
                .WithMany(e => e.ParkEmployees)
                .Map(m => m.ToTable("TENDED_BY", "ThemePark").MapLeftKey("EmployeeID").MapRightKey("RideID"));

            modelBuilder.Entity<Ride>()
                .HasMany(e => e.Maintenances)
                .WithOptional(e => e.Ride)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SeasonPassHolder>()
                .HasMany(e => e.DependentPassHolders)
                .WithOptional(e => e.SeasonPassHolder)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SeasonPassHolder>()
                .HasMany(e => e.SPHLogins)
                .WithOptional(e => e.SeasonPassHolder)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Price)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.ADMITTED_BY)
                .WithRequired(e => e.Ticket)
                .HasForeignKey(e => e.TicketID);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.SeasonPassHolders)
                .WithOptional(e => e.Ticket)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TicketCode>()
                .HasMany(e => e.Tickets)
                .WithOptional(e => e.TicketCode1)
                .HasForeignKey(e => e.TicketCode);
        }
    }
}
