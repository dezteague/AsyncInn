using System;
using Xunit;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.Services;
using AsyncInn.Data;
using System.Linq;

namespace AsyncInnTest
{
    public class UnitTest1
    {
        [Fact]
        public void CanGetNameofHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Async";

            //can retrieve the name of a hotel
            Assert.Equal("Async", hotel.Name);
        }

        [Fact] 
        public void CanSetNameofHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Async";
            hotel.Name = "AsyncInn";

            //can change the name of a hotel
            Assert.Equal("AsyncInn", hotel.Name);
        }

        [Fact]
        public void CanGetNameofRoom()
        {
            Room room = new Room();
            room.Name = "Seattle Rain";

            //can retrieve the name of a room
            Assert.Equal("Seattle Rain", room.Name);
        }

        [Fact]
        public void CanSetNameofRoom()
        {
            Room room = new Room();
            room.Name = "Seattle";
            room.Name = "Seattle Rain";

            //can change the name of a room
            Assert.Equal("Seattle Rain", room.Name);
        }

        [Fact]
        public void CanGetNameofAmenity()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "HD TV";

            //can retrieve the name of an amenity
            Assert.Equal("HD TV", amenity.Name);
        }

        [Fact]
        public void CanSetNameofAmenity()
        {
            Amenities amenity = new Amenities();
            amenity.Name = "HD TV";
            amenity.Name = "Hi-def TV";

            //can change the name of an amenity
            Assert.Equal("Hi-def TV", amenity.Name);
        }

        [Fact]
        public void CanGetRateofHotelRoom()
        {
            HotelRoom hotelroom = new HotelRoom();
            hotelroom.Rate = 100;

            //can retrieve the rate of a hotel room
            Assert.Equal(100, hotelroom.Rate);
        }

        [Fact]
        public void CanSetRateofHotelRoom()
        {
            HotelRoom hotelroom = new HotelRoom();
            hotelroom.Rate = 100;
            hotelroom.Rate = 150;

            //can change the rate of a hotel room 
            Assert.Equal(150, hotelroom.Rate);
        }

        [Fact]
        public void CanGetRoomAmenityID()
        {
            Room room = new Room();
            room.ID = 1;
            Amenities amenity = new Amenities();
            amenity.ID = 1;

            //can retrieve amenity id for a specific room
            Assert.Equal(1, room.ID);
            Assert.Equal(1, amenity.ID);
        }


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
    }
}
