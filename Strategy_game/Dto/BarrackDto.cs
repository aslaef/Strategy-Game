using Strategy_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Dto
{
    public class BarrackDto: BuildingDto
    {
        public int Capacity { get; set; }
        public int Counter { get; set; }

        public BarrackDto(Barrack b)
        {
            BuildingId = b.BuildingId;
            Price = b.Price;
            Capacity = b.Capacity;
            Counter = b.Counter;
            Builder = b.Builder;

        }
    }
}
