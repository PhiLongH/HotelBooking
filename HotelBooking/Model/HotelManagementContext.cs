using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HotelBooking.Model
{
    public class HotelManagementContext : DbContext
    {
        public HotelManagementContext(DbContextOptions<HotelManagementContext> options) : base(options)
        {
        }

        public DbSet<BookingDetail> BookingDetail { get; set; }
        public DbSet<BookingReservation> BookingReservation { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<RoomInformation> RoomInformation { get; set; }
        public DbSet<RoomType> RoomType { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("DBDefault");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingDetail>()
                .HasKey(bd => new { bd.BookingReservationID, bd.RoomID });

            modelBuilder.Entity<BookingReservation>()
                .HasMany(br => br.BookingDetail)
                .WithOne(bd => bd.BookingReservation)
                .HasForeignKey(bd => bd.BookingReservationID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
