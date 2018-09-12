using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Models
{
    public class Farm : Building
    {
       
        public int Population { get; set; }
        public int PotatoesPerRound { get; set; }
        public Farm()
        {
            PotatoesPerRound = 200;
            Population = 50;
            Price = 200;
        }
    }
}
