using System;
using Xunit;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.Services;
using AsyncInn.Data;
using System.Linq;

namespace AsyncInnCRUDtests
{
    public class UnitTest1
    {
        [Fact]
        public async void CanCreateHotel()
        {
            //testing hotel management service
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Downtown";
                hotel.Address = "Seattle";
                hotel.Phone = "(206)555-9999";
                //act 
                HotelManagementService hotelservice = new HotelManagementService(context);

                await hotelservice.CreateHotel(hotel);

                var result = context.Hotels.FirstOrDefault(h => h.ID == h.ID);
                //assert
                Assert.Equal(hotel, result);
            }
        }

        [Fact]
        public async void CanReadHotel()
        {
            //testing hotel management service
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Downtown";
                hotel.Address = "Seattle";
                hotel.Phone = "(206)555-9999";
                //act 
                HotelManagementService hotelservice = new HotelManagementService(context);

                await hotelservice.CreateHotel(hotel);
                await hotelservice.GetHotel(1);

                var result = context.Hotels.FirstOrDefault(h => h.ID == h.ID);
                //assert
                Assert.Equal(hotel, result);
            }
        }

        [Fact]
        public async void CanUpdateHotel()
        {
            //testing hotel management service
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Downtown";
                hotel.Address = "Seattle";
                hotel.Phone = "(206)555-9999";

                hotel.Name = "Waterfront";
                hotel.Address = "Downtown Seattle";
                hotel.Phone = "(206)555-3321";
                
                //act 
                HotelManagementService hotelservice = new HotelManagementService(context);

                await hotelservice.CreateHotel(hotel);
                await hotelservice.UpdateHotel(hotel);

                var result = context.Hotels.FirstOrDefault(h => h.ID == h.ID);
                //assert
                Assert.Equal(hotel, result);
            }
        }

        [Fact]
        public async void CanDeleteHotel()
        {
            //testing hotel management service
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Downtown";
                hotel.Address = "Seattle";
                hotel.Phone = "(206)555-9999";
                //act 
                HotelManagementService hotelservice = new HotelManagementService(context);

                await hotelservice.CreateHotel(hotel);
                await hotelservice.DeleteHotel(1);

                var result = context.Hotels.Any(htl => htl.ID == 1);
                //assert
                Assert.False(result);
            }
        }

        [Fact]
        public async void CanCreateRoom()
        {
            //testing hotel management service
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //arrange
                Room room = new Room();
                room.ID = 1;
                room.Name = "Downtown";
                room.Layout = 0;
                
                //act 
                RoomMangementService roomservice = new RoomMangementService(context);

                await roomservice.CreateRoom(room);

                var result = context.Rooms.FirstOrDefault(r => r.ID == r.ID);
                //assert
                Assert.Equal(room, result);
            }
        }

        [Fact]
        public async void CanReadRoom()
        {
            //testing hotel management service
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //arrange
                Room room = new Room();
                room.ID = 1;
                room.Name = "Downtown";
                room.Layout = 0;

                //act 
                RoomMangementService roomservice = new RoomMangementService(context);

                await roomservice.CreateRoom(room);
                await roomservice.GetRoom(1);

                var result = context.Rooms.FirstOrDefault(r => r.ID == r.ID);
                //assert
                Assert.Equal(room, result);
            }
        }

        [Fact]
        public async void CanUpdateRoom()
        {
            //testing hotel management service
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //arrange
                Room room = new Room();
                room.ID = 1;
                room.Name = "Downtown";
                room.Layout = 0;

                room.Name = "Space Needle";
                room.Layout = 2;

                //act 
                RoomMangementService roomservice = new RoomMangementService(context);

                await roomservice.CreateRoom(room);
                await roomservice.UpdateRoom(room);

                var result = context.Rooms.FirstOrDefault(r => r.ID == r.ID);
                //assert
                Assert.Equal(room, result);
            }
        }

        [Fact]
        public async void CanDeleteRoom()
        {
            //testing hotel management service
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //arrange
                Room room = new Room();
                room.ID = 1;
                room.Name = "Downtown";
                room.Layout = 0;

                //act 
                RoomMangementService roomservice = new RoomMangementService(context);

                await roomservice.CreateRoom(room);
                await roomservice.DeleteRoom(1);

                var result = context.Rooms.Any(rm => rm.ID == 1);
                //assert
                Assert.False(result);
            }
        }

        [Fact]
        public async void CanCreateAmenity()
        {
            //testing hotel management service
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //arrange
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "toaster";
                
                //act 
                AmenityManagementService amenityservice = new AmenityManagementService(context);

                await amenityservice.CreateAmenity(amenity);

                var result = context.Amenities.FirstOrDefault(a => a.ID == a.ID);
                //assert
                Assert.Equal(amenity, result);
            }
        }

        [Fact]
        public async void CanReadAmenity()
        {
            //testing hotel management service
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //arrange
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "toaster";

                //act 
                AmenityManagementService amenityservice = new AmenityManagementService(context);

                await amenityservice.CreateAmenity(amenity);
                await amenityservice.GetAmenity(1);

                var result = context.Amenities.FirstOrDefault(a => a.ID == a.ID);
                //assert
                Assert.Equal(amenity, result);
            }
        }

        [Fact]
        public async void CanUpdateAmenity()
        {
            //testing hotel management service
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //arrange
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "toaster";

                amenity.Name = "breakfast included";

                //act 
                AmenityManagementService amenityservice = new AmenityManagementService(context);

                await amenityservice.CreateAmenity(amenity);
                await amenityservice.UpdateAmenity(amenity);

                var result = context.Amenities.FirstOrDefault(a => a.ID == a.ID);
                //assert
                Assert.Equal(amenity, result);
            }
        }

        [Fact]
        public async void CanDeleteAmenity()
        {
            //testing hotel management service
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //arrange
                Amenities amenity = new Amenities();
                amenity.ID = 1;
                amenity.Name = "toaster";

                //act 
                AmenityManagementService amenityservice = new AmenityManagementService(context);

                await amenityservice.CreateAmenity(amenity);
                await amenityservice.DeleteAmenity(1);

                var result= context.Amenities.Any(am => am.ID == 1);
                //assert
                Assert.False(result);
            }
        }
    }
}
