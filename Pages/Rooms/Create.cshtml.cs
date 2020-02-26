using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcRoom.Data;
using MvcRoom.Models;

namespace MvcRoom
{
    public class CreateModel : PageModel
    {
        private readonly MvcRoom.Data.MvcRoomContext _context;

        public CreateModel(MvcRoom.Data.MvcRoomContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Room Room { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyRoom = new Room();

            if (await TryUpdateModelAsync<Room>(emptyRoom,
                "room",
                r => r.Name, r => r.Length, r => r.Width))
            {
                _context.Room.Add(emptyRoom);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
