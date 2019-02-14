using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelManagementService : IHotelManager
    {
        //connect db to service
        private AsyncInnDbContext _context { get; }

        /// <summary>
        /// sets db context
        /// </summary>
        /// <param name="context"></param>
        public HotelManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }
        
        //create
        /// <summary>
        /// add hotel to the table
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        //read
        /// <summary>
        /// gets all data from hotel table
        /// </summary>
        /// <returns>all hotels</returns>
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            var hotelcount = await _context.Hotels.ToListAsync();
            foreach (var i in hotelcount)
            {
                i.RoomCount = _context.HotelRooms.Where(room => room.HotelID == i.ID).Count();
            }

            return hotelcount;
        }

        public async Task<Hotel> GetHotel(int? id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(htl => htl.ID ==id);
        }

        //update
        /// <summary>
        /// update data for specific hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }

        //delete
        /// <summary>
        /// remove a hotel from the table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteHotel(int id)
        {
            Hotel hotel = _context.Hotels.FirstOrDefault(htl => htl.ID == id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        //confirm hotel Existence
        public bool HotelExists(int id)
        {
            return _context.Hotels.Any(htl => htl.ID == id);
        }
    }
}
