﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly MvcRoomContext _context;

        public IndexModel(MvcRoomContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Room> Room { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_des" : "";

            IQueryable<Room> roomsIQ = from r in _context.Room
                                       select r;

            switch (sortOrder)
            {
                case "name_desc":
                    roomsIQ = roomsIQ.OrderByDescending(r => r.Name);
                    break;
                default:
                    roomsIQ = roomsIQ.OrderBy(r => r.Name);
                    break;
            }

            Room = await roomsIQ.AsNoTracking().ToListAsync();
        }
    }
}
