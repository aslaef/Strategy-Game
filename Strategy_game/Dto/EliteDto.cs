using Strategy_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Dto
{
    public class EliteDto: UnitDto
    {
        public EliteDto(Elite a)
        {
            if (a != null)
            {
                UnitId = a.UnitId;
                Counter = a.Counter;
                Price = a.Price;
                Salary = a.Salary;
                Food = a.Food;
                Atk = a.Atk;
                Def = a.Def;
            }
        }
    }
}
