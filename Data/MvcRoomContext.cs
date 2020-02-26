using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcRoom.Models;

namespace MvcRoom.Data
{
    public class MvcRoomContext : DbContext
    {
        public MvcRoomContext (DbContextOptions<MvcRoomContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Room { get; set; }
        public DbSet<Door> Doors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Door>().ToTable("Door");
        }
    }
}
