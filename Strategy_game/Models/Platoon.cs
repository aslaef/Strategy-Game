using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Models
{
    public class Platoon
    {
        public int PlatoonId { get; set; }

        public virtual Archer Archers { get; set; }
        public virtual Horseman Horsemans { get; set; }
        public virtual Elite Soldiers { get; set; }

        public int Intent { get; set; }
        public virtual  Country Owner { get; set; }
        public Platoon()
        {
            

        }
    }
}
