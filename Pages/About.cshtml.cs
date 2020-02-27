using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcRoom.Models.RoomHeightGroup;
using MvcRoom.Data;

namespace MvcRoom.Pages
{
    public class AboutModel : PageModel
    {
        private readonly MvcRoomContext _context;

        public AboutModel(MvcRoomContext context)
        {
            _context = context;
        }

        public IList<RoomHeightGroup> Room { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<RoomHeightGroup> data =
                from room in _context.Room
                group room by room.Length into roomGroup
                select new RoomHeightGroup()
                {
                    RoomHeight = roomGroup.Key,
                    RoomCount = roomGroup.Count()
                };

            Room = await data.AsNoTracking().ToListAsync();
        }
    }
}