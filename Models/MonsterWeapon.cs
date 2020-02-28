using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcRoom.Models
{
    public class MonsterWeapon
    {
        public int MonsterWeaponID { get; set; }
        public string MonsterWeaponName { get; set; }
        public string WeaponType { get; set; }
        public int Damage { get; set; }
        public int MonsterID { get; set; }
    }
}
