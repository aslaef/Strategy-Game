using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public int Score { get; set; }
        public virtual CountryDto OwnedCountry { get; set; }

        public int Money { get; set; }
    }
}
