using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Models
{
    public class Barrack : Building
    {
        public int Capacity { get; set; }
       

        public Barrack()
        {
            Capacity = 200;
            Price = 1000;
        }
    }
}
