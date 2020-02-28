using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRoom.Models
{
    public class Monster
    {
        public int MonsterID { get; set; }
        [Required]
        [Display(Name = "Monster Type")]
        [StringLength(20)]
        public string Type { get; set; }
        [Required]
        [StringLength(20)]
        public string Called { get; set; }

        public string MonsterName
        {
            get
            {
                return "A " + Type + " called " + Called;
            }
        }

        public ICollection<MonsterWeapon> MonsterWeapons { get; set; }
    }
}
