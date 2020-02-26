using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcRoom.Data;
using MvcRoom.Models;

namespace MvcRoom
{
    public class DeleteModel : PageModel
    {
        private readonly MvcRoomContext _context;

        public DeleteModel(MvcRoomContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Room Room { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await _context.Room
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Room == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed.Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            try
            {
                _context.Room.Remove(room);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
        }
    }
}
