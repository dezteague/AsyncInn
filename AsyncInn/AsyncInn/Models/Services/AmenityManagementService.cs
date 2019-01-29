using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenityManagementService : IAmenityManager
    {
        private AsyncInnDbContext _context { get; }

        public AmenityManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public void CreateAmenity(Amenities amenities)
        {
            throw new NotImplementedException();
        }

        public void DeleteAmenity(Amenities amenities)
        {
            throw new NotImplementedException();
        }

        public void DeleteAmenity(int id)
        {
            throw new NotImplementedException();
        }

        public void EditAmenity(Amenities amenities)
        {
            throw new NotImplementedException();
        }

        public Room GetAmenity(int id)
        {
            throw new NotImplementedException();
        }

        public Room GetAmenity(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateAmenity(Amenities amenities)
        {
            throw new NotImplementedException();
        }
    }
}
