using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcRoom.Models
{
    public class Door
    {
        public int DoorID { get; set; }
        public int RoomID { get; set; }
        public string Wall { get; set; }
        public int Location { get; set; }
    }
}
