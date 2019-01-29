using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        //create 
        Task CreateHotel(Hotel hotel);

        //read

        Task<Hotel> GetHotel(int id);

        Task<IEnumerable<Hotel>> GetHotels();

        //update/edit

        void UpdateHotel(Hotel hotel);

        //delete

        void DeleteHotel(int id);
    }
}
