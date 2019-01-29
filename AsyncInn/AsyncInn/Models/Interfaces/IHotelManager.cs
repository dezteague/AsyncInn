using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IHotelManager
    {
        //create 
        void CeateHotel(Hotel hotel);

        //read

        Room GetHotel(int id);

        Room GetHotel(string name);

        //update/edit

        void UpdateHotel(Hotel hotel);

        //delete
        void DeleteHotel(Hotel hotel);

        void DeleteHotel(int id);
    }
}
