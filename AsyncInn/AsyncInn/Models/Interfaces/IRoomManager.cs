using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        //create 
        Task CreateRoom(Room room);

        //read

        Task<Room> GetRoom(int id);

        Task<IEnumerable<Room>> GetRooms();

        //update/edit

        void UpdateRoom(Room room);

        //delete

        void DeleteRoom(int id);
    }
}
