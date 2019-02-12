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

        /// <summary>
        /// sets db context
        /// </summary>
        /// <param name="context"></param>
        public AmenityManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        //create
        /// <summary>
        /// add amenity to the table
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns>table with new amenity</returns>
        public async Task CreateAmenity(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
        }

        //read
        /// <summary>
        /// gets all data from amenity table
        /// </summary>
        /// <returns>all amenities</returns>
        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetAmenity(int? id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(amen => amen.ID == id);
        }

        //update
        /// <summary>
        /// update data for a specific amenity
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns>updated amenity</returns>
        public async Task UpdateAmenity(Amenities amenities)
        {
            _context.Amenities.Update(amenities);
            await _context.SaveChangesAsync();
        }

        //delete
        /// <summary>
        /// removes an amenity from the table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>updated table</returns>
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
