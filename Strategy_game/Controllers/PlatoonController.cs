using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Strategy_game.Dto;
using Strategy_game.Models;
using Strategy_game.ServiceInterfaces;
using Strategy_game.Services;

namespace Strategy_game.Controllers
{
    
    public class PlatoonController : Controller
    {
        public readonly IPlatoonService ps;

        public PlatoonController(IPlatoonService ips)
        {
            ps = ips;
        }

        [HttpPost, Route("api/PostPlatoon/{id}")]
        public IActionResult postPlatoon( int id)
        {
            var t = id;

            ps.PostPlatoon(id);



            return NoContent();
        }

        [HttpGet, Route("api/GetPlatoon/{id}")]
        public IActionResult GetPlatoon(int id)
        {
            var p = ps.GetPlatoon(id);

            var dto = new PlatoonDto()
            {
                PlatoonId = p.PlatoonId,
                a = new ArcherDto(p.Archers),
                h = new HorsemanDto(p.Horsemans),
                s = new EliteDto(p.Soldiers),
                c = new CountryDto(p.Owner)
            };

            return Ok(dto);
        }


        [HttpPut, Route("api/PutUnitToPlatoon/{platoonId}/{platoonUnitId}")]
        public IActionResult PutArcherInPlatoon(int platoonId, int platoonUnitId)
        {
            var p = ps.putUnitToPlatoon(platoonId, platoonUnitId);

            var dto = new PlatoonDto()
            {
                PlatoonId = p.PlatoonId,
                a = new ArcherDto(p.Archers),
                h = new HorsemanDto(p.Horsemans),
                s = new EliteDto(p.Soldiers),
                c = new CountryDto(p.Owner),
            };

            return Ok(dto);
        }
        [HttpPut, Route("api/PutHorsemanInPlatoon/{id}/{platoonId}")]
        public IActionResult PutHorsemanInPlatoon(int id, int platoonId)
        {
            var p = ps.putHorsemanInPlatoon(id, platoonId);

            var dto = new PlatoonDto()
            {
                PlatoonId = p.PlatoonId,
                a = new ArcherDto(p.Archers),
                h = new HorsemanDto(p.Horsemans),
                s = new EliteDto(p.Soldiers),
                c = new CountryDto(p.Owner),
            };

            return Ok(dto);
        }
        [HttpPut, Route("api/PutSoldierInPlatoon/{id}/{platoonId}")]
        public IActionResult PutSoldierInPlatoon(int id, int platoonId)
        {
            var p = ps.putSoldierInPlatoon(id, platoonId);

            var dto = new PlatoonDto()
            {
                PlatoonId = p.PlatoonId,
                a = new ArcherDto(p.Archers),
                h = new HorsemanDto(p.Horsemans),
                s = new EliteDto(p.Soldiers),
                c = new CountryDto(p.Owner),
            };

            return Ok(dto);
        }


        [HttpPut, Route("api/AttackCountry/{fromId}/{toId}")]
        public IActionResult AttackCountry(int fromId, int toId)
        {
            var p = ps.setIntent(fromId, toId);

            var dto = new PlatoonDto()
            {
                PlatoonId = p.PlatoonId,
                a = new ArcherDto(p.Archers),
                h = new HorsemanDto(p.Horsemans),
                s = new EliteDto(p.Soldiers),
                c = new CountryDto(p.Owner),
            };

            return Ok(dto);
        }



    }
}