using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Dto
{
    public class UnitDto
    {
        public int UnitId { get; set; }
        public bool DefenderPosition { get; set; }

        public int Counter { get; set; }
        public int Atk { get; set; }

        public int Def { get; set; }
        public int Price { get; set; }
        public int Food { get; set; }
        public int Salary { get; set; }
    }
}
