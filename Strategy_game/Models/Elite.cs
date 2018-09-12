﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Models
{
    
    public class Elite : Unit
    {
        
        public Elite()
        {
            DefenderPosition = false;
            Atk = 2;
            Def = 6;
            Price = 50;
            Food = 20;
            Salary = 10;
        }
    }
}
