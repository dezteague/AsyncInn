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
