using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcRoom.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }

        public ICollection<Door> Doors { get; set; }
    }
}
