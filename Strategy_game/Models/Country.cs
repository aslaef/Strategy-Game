using Strategy_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Models
{
    public class Country
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }
        public bool Tractor { get; set; }
        public bool Combine { get; set; }
        public bool Wall { get; set; }
        public bool Commander { get; set; }
        public bool Tactican { get; set; }
        public bool Alchemy { get; set; }

        public int Gold { get; set; }

        public int Potatoes { get; set; }

        public Country()
        {
            
        }

        public ICollection<Unit> Units { get; set; }

        public ICollection<Building> Buildings { get; set; }

        public ICollection<Platoon> Platoons { get; set; }

        //public virtual User ownUser { get; set; }
    }
}
