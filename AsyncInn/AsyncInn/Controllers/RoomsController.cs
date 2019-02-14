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
    public class RoomsController : Controller
    {
        private readonly IRoomManager _context;
        private readonly AsyncInnDbContext _rooms;

        public RoomsController(IRoomManager context, AsyncInnDbContext rooms)
        {
            _context = context;
            _rooms = rooms;
        }

        // GET: Rooms
        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string searchString)
        {
            //var rooms = from r in _rooms.Rooms
            //             select r;
            var roomcount = await _rooms.Rooms.ToListAsync();
            foreach (var i in roomcount)
            {
                i.AmenityCount = _rooms.RoomAmenities.Where(room => room.RoomID == i.ID).Count();
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                var rooms = _rooms.Rooms.Where(rm => rm.Name.Contains(searchString));
                return View(rooms);
            }
            return View(roomcount);
        }

        // GET: Rooms/Details/5
        /// <summary>
        /// show details of a room
        /// </summary>
        /// <param name="id"></param>
        /// <returns>room view</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.GetRoom(id);
                
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        /// <summary>
        /// Create a room
        /// </summary>
        /// <returns>room view</returns>
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        /// <summary>
        /// Posts search results
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>index view</returns>
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /// <summary>
        /// Show the details of new amentiy
        /// </summary>
        /// <param name="id"></param>
        /// <param name="room"></param>
        /// <returns>index view</returns>
        public async Task<IActionResult> Create([Bind("ID,Name,RoomLayout")] Room room)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateRoom(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        /// <summary>
        /// Show details of a room for editing
        /// </summary>
        /// <param name="id"></param>
        /// <returns>room view</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /// <summary>
        /// Display details of an room that were edited
        /// </summary>
        /// <param name="id"></param>
        /// <param name="room"></param>
        /// <returns>amenity view</returns>
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,RoomLayout")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await _context.UpdateRoom(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.ID))
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
            return View(room);
        }

        // GET: Rooms/Delete/5
        /// <summary>
        /// Shows room to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete view page</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.GetRoom(id);
                
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        /// <summary>
        /// Asks user to confirm deletion
        /// </summary>
        /// <param name="id"></param>
        /// <returns>amenity view page</returns>
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.RoomExists(id);
        }
    }
}
