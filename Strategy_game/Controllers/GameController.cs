using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Strategy_game.Context;
using Strategy_game.Models;
using Strategy_game.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Controllers
{
    public class GameController : Controller
    {
        public readonly ApplitactionDbContext _dbcontext;
        public readonly IStrategyService _service;

        public GameController(ApplitactionDbContext dbcontext, IStrategyService service)
        {
            _dbcontext = dbcontext;
            _service = service;
        }

        [HttpPost, Route("api/createNewGame")]
        public async Task<Game> PostGame()
        {
            var ng = new Game();
            _dbcontext.Games.Add(ng);
            await _dbcontext.SaveChangesAsync();
            return ng;
        }

        [HttpGet, Route("api/getGame/{id}")]
        public IActionResult GettGame(int id)
        {
            var G =_dbcontext.Games.Where(g => g.GameId == id).FirstOrDefault();
            return Ok(G);
        }

        [HttpPut, Route("api/nextRound/{id}")]
        public IActionResult NextRound(int id)
        {

            //RecurringJob.AddOrUpdate(
            //    () => this._service.DoOneRound(id),
            //    Cron.Minutely);
            var x = this._service.DoOneRound();
            return Ok(x);
            //    _dbcontext.Games.Where(g => g.GameId == id).FirstOrDefault();
            //G.RoundNumber += 1;
            //_dbcontext.Entry(G).State = EntityState.Modified;

            //var countries = _dbcontext.Countries.ToList();
            //foreach(Country c in countries)
            //{
            //    var archer = _dbcontext.Archers.Where(a => a.OwnerCountry == c).FirstOrDefault();
            //    var horse = _dbcontext.Horsemans.Where(a => a.OwnerCountry == c).FirstOrDefault();
            //    var soldier = _dbcontext.Elites.Where(a => a.OwnerCountry == c).FirstOrDefault();
            //    var farm = _dbcontext.Farms.Where(a => a.OwnerCountry == c).FirstOrDefault();
            //    var barrack = _dbcontext.Barracks.Where(a => a.OwnerCountry == c).FirstOrDefault();

            //    var Plusgold = farm.Counter * farm.Population;
            //    var Minusgold = archer.Counter + horse.Counter + soldier.Counter;
            //    var Pluspotatoes = farm.Counter * farm.PotatoesPerRound;
            //    var MinusPotatoes = archer.Food + horse.Food + soldier.Food;

            //    c.Gold += Plusgold - Minusgold;
            //    c.Potatoes += Pluspotatoes - MinusPotatoes;

            //    _dbcontext.Entry(c).State = EntityState.Modified;

            //}



            //_dbcontext.SaveChanges();
            
        }
        //public void working() { return Ok(this._service.DoOneRound(id)); }


        [HttpPost, Route("api/DefUser")]
        public async Task<IActionResult> PostDef([FromBody] User user)
        {

            
            var c = new Country()
            {
                CountryName = "deffaultName"
            };

            _service.AddCountry(c);

            var newuser = new User()
            {
                OwnedCountry = c,
                Name = user.Name
            };
            var newunit = new Archer()
            {
                OwnerCountry = c
            };

            _dbcontext.Archers.Add(newunit);
            _dbcontext.Users.Add(newuser);
            await _dbcontext.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }














        [HttpGet]
        [Route("api/user/{name}")]
        public ActionResult SelectUser(string name)
        {
            User newUser = new User();

            var tempUser = _dbcontext.Users.Where(u => u.Name == name).SingleOrDefault();
            if (tempUser == null)
            {
                return NotFound();
            }
            newUser = tempUser;
            return Ok(newUser);
        }

        [HttpGet]
        [Route("api/getunits/{id}")]
        public async Task<object> SelectUser(int id)
        {
            var c = _service.GetCountryById(id);

            var asd = _dbcontext.Archers.Where(u => u.OwnerCountry == c).ToList();
            return asd;
            
            
        }


    }
}
