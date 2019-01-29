using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    interface IAmenityManager
    {
        //create 
        void CreateAmenity(Amenities amenities);

        //read

        Room GetAmenity(int id);

        Room GetAmenity(string name);

        //update/edit

        void UpdateAmenity(Amenities amenities);

        //delete
        void DeleteAmenity(Amenities amenities);

        void DeleteAmenity(int id);
    }
}
