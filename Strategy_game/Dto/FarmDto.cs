using Strategy_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Dto
{
    public class FarmDto : BuildingDto
    {
        public int Counter { get; set; }
        public int Population { get; set; }
        public int PotatoesPerRound { get; set; }

        public FarmDto(Farm f)
        {
            BuildingId = f.BuildingId;
            Price =f.Price;
            Counter = f.Counter;
            Population = f.Population;
            PotatoesPerRound = f.PotatoesPerRound;
            Builder = f.Builder;
        }
    }
}
