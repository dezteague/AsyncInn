using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelManager _context;
        private readonly AsyncInnDbContext _hotels;

        public HotelsController(IHotelManager context, AsyncInnDbContext hotels)
        {
            _context = context;
            _hotels = hotels;
        }

        // GET: Hotels
        /// <summary>
        /// Get all hotels
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>hotel view</returns>
        public async Task<IActionResult> Index(string searchString)
        {
            var hotels = from h in _hotels.Hotels
                         select h;
            if (!String.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(htl => htl.Name.Contains(searchString));
            }
            return View(await hotels.ToListAsync());
        }

        // GET: Hotels/Details/5
        /// <summary>
        /// show details of a hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns>details view</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.GetHotel(id);
                
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        /// <summary>
        /// Create a hotel
        /// </summary>
        /// <returns>create view</returns>
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateHotel(hotel);
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        /// <summary>
        /// Shows details of a hotel for editing
        /// </summary>
        /// <param name="id"></param>
        /// <returns>edit view</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

   

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateHotel(hotel);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        /// <summary>
        /// Show hotel to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete view</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.GetHotel(id);
                
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await _context.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
            return _context.HotelExists(id);
        }
    }
}
