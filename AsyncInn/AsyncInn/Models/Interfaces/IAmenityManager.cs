using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenityManager
    {
        //create 
        Task CreateAmenity(Amenities amenities);

        //read

        Task<Amenities> GetAmenity(int id);

        Task<IEnumerable<Amenities>> GetAmenities();

        //update/edit

        void UpdateAmenity(Amenities amenities);

        //delete

        void DeleteAmenity(int id);
    }
}
