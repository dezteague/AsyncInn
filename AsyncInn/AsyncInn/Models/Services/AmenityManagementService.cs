using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenityManagementService : IAmenityManager
    {
        //connect database to service
        private AsyncInnDbContext _context { get; }

        public AmenityManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        //create
        public async Task CreateAmenity(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
        }

        //read
        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetAmenity(int? id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(amen => amen.ID == id);
        }

        //update
        public async Task UpdateAmenity(Amenities amenities)
        {
            _context.Amenities.Update(amenities);
            await _context.SaveChangesAsync();
        }

        //delete
        public async Task DeleteAmenity(int id)
        {
            Amenities amenity = _context.Amenities.FirstOrDefault(amen => amen.ID == id);
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();
        }

        //confirm Amenity Existence
        public bool AmenityExists(int id)
        {
            return _context.Amenities.Any(amen => amen.ID == id);
        }
    }
}
