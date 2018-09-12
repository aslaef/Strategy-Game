using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Models
{
    public abstract class Building
    {
        public virtual Country OwnerCountry { get; set; }
        public int BuildingId { get; set; }

        public int Price { get; set; }

        public int Counter { get; set; }

        public int Builder { get; set; }

    }
}
