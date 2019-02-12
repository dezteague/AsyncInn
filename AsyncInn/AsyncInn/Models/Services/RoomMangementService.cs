using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomMangementService : IRoomManager
    {
        //connect db to service
        private AsyncInnDbContext _context { get; }

        /// <summary>
        /// sets db to context
        /// </summary>
        /// <param name="context"></param>
        public RoomMangementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        //create
        /// <summary>
        /// add room to the table
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public async Task CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        //read
        /// <summary>
        /// gets all data from rooms table
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoom(int? id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(rm => rm.ID == id);
        }

        //update
        /// <summary>
        /// update data for a specific room
        /// </summary>
        /// <param name="room"></param>
        /// <returns>updated room</returns>
        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        //delete
        /// <summary>
        /// removes a room from the table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>updated table</returns>
        public async Task DeleteRoom(int id)
        {
            Room room = _context.Rooms.FirstOrDefault(rm => rm.ID == id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        //Confirm room existence
        public bool RoomExists(int id)
        {
            return _context.Rooms.Any(ex => ex.ID == id);
        }
    }
}
