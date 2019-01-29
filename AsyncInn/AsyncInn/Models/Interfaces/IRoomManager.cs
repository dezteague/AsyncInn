using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IRoomManager
    {
        //create 
        void CreateRoom(Room room);

        //read

        Room GetRoom(int id);

        Room GetRoom(string name);

        //update/edit

        void UpdateRoom(Room room);

        //delete
        void DeleteRoom(Room room);

        void DeleteRoom(int id);
    }
}
