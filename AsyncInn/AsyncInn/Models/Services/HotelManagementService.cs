using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelManagementService : IHotelManager
    {
        private AsyncInnDbContext _context { get; }

        public HotelManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public void CreateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public void DeleteHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public void DeleteHotel(int id)
        {
            throw new NotImplementedException();
        }

        public void EditHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Room GetHotel(int id)
        {
            throw new NotImplementedException();
        }

        public Room GetHotel(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
