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
    public class DetailsModel : PageModel
    {
        private readonly MvcRoom.Data.MvcRoomContext _context;

        public DetailsModel(MvcRoom.Data.MvcRoomContext context)
        {
            _context = context;
        }

        public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Room = await _context.Room.FirstOrDefaultAsync(m => m.ID == id);
            Room = await _context.Room
                .Include(r => r.Doors)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Room == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
