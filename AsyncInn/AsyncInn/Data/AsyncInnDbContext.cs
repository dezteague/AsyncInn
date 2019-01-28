using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //composite key associations
            modelBuilder.Entity<HotelRoom>().HasKey(ce => new { ce.HotelID, ce.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(ce => new { ce.AmenitiesID, ce.RoomID });

            //seed database
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Async Downtown Seattle",
                    Address = "Seattle, WA",
                    Phone = "(206)555-1234"
                },

                new Hotel
                {
                    ID = 2,
                    Name = "Async West Seattle",
                    Address = "West Seattle, WA",
                    Phone = "(206)555-5678"
                },

                new Hotel
                {
                    ID = 3,
                    Name = "Async Bellevue",
                    Address = "Bellevue, WA",
                    Phone = "(425)555-9012"
                },

                new Hotel
                {
                    ID = 4,
                    Name = "Async Olympia",
                    Address = "Olympia, WA",
                    Phone = "(360)555-2468"
                },

                new Hotel
                {
                    ID = 5,
                    Name = "Async Portland",
                    Address = "Portland, Oregon",
                    Phone = "(503)555-9876"
                }
                );
        }

        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
