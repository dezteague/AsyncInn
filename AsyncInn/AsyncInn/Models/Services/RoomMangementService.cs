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
        private AsyncInnDbContext _context { get; }

        public RoomMangementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        //create
        public async Task CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        //read
        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoom(int? id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(rm => rm.ID == id);
        }

        //update
        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        //delete
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
