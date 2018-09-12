using Strategy_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Dto
{
    public class CountryDto
    {
        public CountryDto(Country c)
        {
            this.CountryId = c.CountryId;
            this.Alchemy = c.Alchemy;
            
            this.Combine = c.Combine;
            this.Commander = c.Commander;
            this.CountryName = c.CountryName;
            this.Tactican = c.Tactican;
            this.Tractor = c.Tractor;
            this.Wall = c.Wall;
            this.Potatoes = c.Potatoes;
            this.Gold = c.Gold;
        }
        public CountryDto()
        {

        }

        public int CountryId { get; set; }

        public string CountryName { get; set; }
        public bool Tractor { get; set; }
        public bool Combine { get; set; }
        public bool Wall { get; set; }
        public bool Commander { get; set; }
        public bool Tactican { get; set; }
        public bool Alchemy { get; set; }

        public int Gold { get; set; }
        public int Potatoes { get; set; }


    }
}
