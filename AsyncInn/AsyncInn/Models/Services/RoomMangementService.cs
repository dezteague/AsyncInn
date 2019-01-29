using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
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

        public void CreateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoom(int id)
        {
            throw new NotImplementedException();
        }

        public Room GetRoom(int id)
        {
            throw new NotImplementedException();
        }

        public Room GetRoom(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public void EditRoom(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
