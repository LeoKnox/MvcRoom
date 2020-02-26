using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcRoom.Data;
using MvcRoom.Models;

namespace MvcRoom
{
    public class EditModel : PageModel
    {
        private readonly MvcRoom.Data.MvcRoomContext _context;

        public EditModel(MvcRoom.Data.MvcRoomContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Room = await _context.Room.FirstOrDefaultAsync(m => m.ID == id);
            Room = await _context.Room.FindAsync(id);

            if (Room == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var roomToUpdate = await _context.Room.FindAsync(id);

            if (roomToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Room>(
                roomToUpdate,
                "room",
                s => s.Name, s => s.Length, s => s.Width))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.ID == id);
        }
    }
}
