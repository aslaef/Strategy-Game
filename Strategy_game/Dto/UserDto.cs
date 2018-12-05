using Strategy_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string Pass { get; set; }
        public int Score { get; set; }
        public int CountryId { get; set; }
        public UserDto()
        {

        }
        public UserDto(User u)
        {
            Name = u.Name;
            CountryName = u.OwnedCountry.CountryName;
            CountryId = u.OwnedCountry.CountryId;
            Score = u.Score;

            
        }
    }
}
