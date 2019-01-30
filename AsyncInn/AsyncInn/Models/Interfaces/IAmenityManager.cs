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

        Task<Amenities> GetAmenity(int? id);

        Task<IEnumerable<Amenities>> GetAmenities();

        //update/edit

        Task UpdateAmenity(Amenities amenities);

        //delete

        Task DeleteAmenity(int id);

        bool AmenityExists(int id);
    }
}
