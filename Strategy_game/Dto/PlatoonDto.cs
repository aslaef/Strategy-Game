using Strategy_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Dto
{
    public class PlatoonDto
    {
        public int PlatoonId;
        public ArcherDto a;
        public HorsemanDto h;
        public EliteDto s;
        public CountryDto c;


        public PlatoonDto(Platoon p)
        {
            PlatoonId = p.PlatoonId;
            a = new ArcherDto(p.Archers);
            h = new HorsemanDto(p.Horsemans);
            s = new EliteDto(p.Soldiers);
            c = new CountryDto(p.Owner);
        }

        public PlatoonDto()
        {

        }

    }
}
