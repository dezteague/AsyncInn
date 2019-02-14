using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    public class HotelRoomsController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomsController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: HotelRooms
        /// <summary>
        /// Gets all hotel rooms 
        /// </summary>
        /// <returns>hotel room view</returns>
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel).Include(h => h.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: HotelRooms/Details/5
        /// <summary>
        /// show the details of a hotel room
        /// </summary>
        /// <param name="hotelid"></param>
        /// <param name="roomid"></param>
        /// <returns>details view</returns>
        public async Task<IActionResult> Details(int? hotelid, int? roomid)
        {
            if (hotelid == null || roomid == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == hotelid && m.RoomID ==roomid );
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRooms/Create
        /// <summary>
        /// Create a hotel room
        /// </summary>
        /// <returns>create view</returns>
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(hotelRoom);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRoom.HotelID);
                ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "ID", hotelRoom.RoomID);
                return View(hotelRoom);
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Index));
            }
            
        }

        // GET: HotelRooms/Edit/5
        /// <summary>
        /// Displays details of a hotel room for editing
        /// </summary>
        /// <param name="hotelid"></param>
        /// <param name="roomid"></param>
        /// <returns>edit view</returns>
        public async Task<IActionResult> Edit(int? hotelid, int? roomid)
        {
            if (hotelid == null || roomid == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == hotelid && m.HotelID == roomid);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int hotelid, int roomid, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
        

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.HotelID))
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
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "ID", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRooms/Delete/5
        /// <summary>
        /// Show hotel room to be deleted
        /// </summary>
        /// <param name="hotelid"></param>
        /// <param name="roomid"></param>
        /// <returns>delete view page</returns>
        public async Task<IActionResult> Delete(int hotelid, int roomid)
        {

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == hotelid && m.RoomID == roomid);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int hotelid, int roomid)
        {
            var hotelRoom = await _context.HotelRooms.Include(h => h.Hotel)
                .Include(h => h.Room).FirstOrDefaultAsync(m => m.HotelID == hotelid && m.RoomID == roomid);

            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelID == id);
        }
    }
}
