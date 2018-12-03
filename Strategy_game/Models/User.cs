using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int Score { get; set; }
        public virtual Country OwnedCountry { get; set; }
        public int Gold { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

    }
}
