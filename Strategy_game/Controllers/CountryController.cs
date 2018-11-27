using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Strategy_game.Context;
using Strategy_game.Dto;
using Strategy_game.Models;
using Strategy_game.ServiceInterfaces;
using Strategy_game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Controllers
{


    public class CountryController : Controller
    {
        public readonly ApplitactionDbContext _dbcontext;
        public readonly IStrategyService _service;
        public readonly IUnitBuildingSetterService _ibserv;

        public CountryController(ApplitactionDbContext dbcontext, IStrategyService service, IUnitBuildingSetterService s2)
        {
            _dbcontext = dbcontext;
            _service = service;
            _ibserv = s2;
        }


        [HttpGet]
        [Route("api/somecont/{id}")]
        public ActionResult Selectcountry(int id)
        {
            var tempCountry = _service.GetCountryById(id);
            if (tempCountry == null)
            {
                return NotFound();
            }
            CountryDto newcountry = new CountryDto(tempCountry);
            return Ok(newcountry);
        }


        // GET: api/Values/GetCountry
        [HttpGet, Route("api/someconts")]
        public async Task<object> GetCountry()
        {
            return await _dbcontext.Countries.ToListAsync();
        }


        


        [HttpPost, Route("api/poster")]
        public async Task<IActionResult> PostCountry([FromBody] Country country)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            country.Gold = 1500;
            _service.AddCountry(country);

            return CreatedAtAction("GetCountry", new { id = country.CountryId }, country);
        }

        #region ubserv
        [HttpGet]
        [Route("api/getArcherFor/{id}")]
        public ActionResult getArcherFor(int id)
        {
            var a = _ibserv.getA(id);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }



        [HttpGet]
        [Route("api/getHorsemanFor/{id}")]
        public ActionResult getHorsemanFor(int id)
        {
            var a = _ibserv.getH(id);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
        [HttpGet]
        [Route("api/getSoldierFor/{id}")]
        public ActionResult getSoldierFor(int id)
        {
            var a = _ibserv.getS(id);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
        [HttpGet]
        [Route("api/getFarmFor/{id}")]
        public ActionResult getFarmFor(int id)
        {
            var a = _ibserv.getF(id);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
        [HttpGet]
        [Route("api/getBarrackFor/{id}")]
        public ActionResult getBarrackFor(int id)
        {
            var a = _ibserv.getB(id);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
        //POST UNITS**************************************************************************************
        [HttpPost, Route("api/addUnittoCountry/{id}")]
        public async Task<IActionResult> PostArcherToCountry(int id)
        {
            var a = await _ibserv.postA(id);
            return Ok(a);
        }
        [HttpPost, Route("api/addHorsemanToCountry/{id}")]
        public async Task<IActionResult> PostHorsemanToCountry(int id)
        {

            var a = await _ibserv.postH(id);
            return Ok(a);
        }
        [HttpPost, Route("api/addSoldierToCountry/{id}")]
        public async Task<IActionResult> PostSoldierToCountry(int id)
        {

            await _ibserv.postS(id);
            return null;
        }


        //POST UNITS**************************************************************************************
        [HttpPost, Route("api/addFarmToCountry/{id}")]
        public async Task<IActionResult> PostFarmToCountry(int id)
        {

            await _ibserv.postF(id);
            return null;
        }
        [HttpPost, Route("api/addBarrakToCountry/{id}")]
        public async Task<IActionResult> PostBarrakToCountry(int id)
        {


            await _ibserv.postB(id);
            return null;
        }


        //*****************************************************************************************************















        // PUT: api/Countriessss/5
        [HttpPut, Route("api/putUnittoCountry/{id}")]
        public async Task<IActionResult> PutUnit([FromRoute] int id)
        {
            var originalA = await _ibserv.putA(id);

            return Ok(originalA);
        }
        [HttpPut, Route("api/putHorsemanToCountry/{id}")]
        public async Task<IActionResult> PutHorseman([FromRoute] int id)
        {
            var originalA = await _ibserv.putH(id);

            return Ok(originalA);
        }
        [HttpPut, Route("api/putSoldierToCountry/{id}")]
        public async Task<IActionResult> PutElite([FromRoute] int id)
        {
            var originalA = await _ibserv.putS(id);

            return Ok(originalA);
        }
        [HttpPut, Route("api/putFarmToCountry/{id}")]
        public async Task<IActionResult> PutFarm([FromRoute] int id)
        {
            var originalA = await _ibserv.putF(id);

            return Ok(originalA);
        }
        [HttpPut, Route("api/putBarrackToCountry/{id}")]
        public async Task<IActionResult> PutBarrack([FromRoute] int id)
        {
            var originalA = await _ibserv.putB(id);

            return Ok(originalA);
        }
        #endregion
        //********************************************************************************************************************

        [HttpPut, Route("api/putupgrade/{id}/{id2}")]
        public async Task<IActionResult> putUpgrade([FromRoute] int id, [FromRoute] int id2)
        {
            var C = _dbcontext.Countries.Where(c => c.CountryId == id).FirstOrDefault();
            int countedUpradges = 0;
            if (C.Tractor == true)
            {
                countedUpradges++;
            }
            if (C.Combine == true)
            {
                countedUpradges++;
            }
            if (C.Wall == true)
            {
                countedUpradges++;
            }
            if (C.Commander == true)
            {
                countedUpradges++;
            }
            if (C.Tactican == true)
            {
                countedUpradges++;
            }
            if (C.Alchemy == true)
            {
                countedUpradges++;
            }

            if(countedUpradges < 4) { 
                if (id2 == 1)
                {
                    C.Tractor = true;
                }
                if (id2 == 2)
                {
                    C.Combine = true;
                }
                if (id2 == 3)
                {
                    C.Wall = true;
                }
                if (id2 == 4)
                {
                    C.Commander = true;
                }
                if (id2 == 5)
                {
                    C.Tactican = true;
                }
                if (id2 == 6)
                {
                    C.Alchemy = true;
                }
            }

            _dbcontext.Entry(C).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return Ok(C);
        }

        [HttpPut, Route("api/countryRound/{id}")]
        public async Task<IActionResult> PutC([FromRoute] int id, [FromBody] Country c)
        {
            var country = _dbcontext.Countries.Where(C => C.CountryId == id).FirstOrDefault();
            country.Gold += c.Gold;
            country.Potatoes += c.Potatoes;
            _dbcontext.Entry(country).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return Ok(country);
        }


        [HttpPost, Route("api/addUser")]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }
        // GET: api/Values/GetCountry
        [HttpGet, Route("api/getUsers")]
        public async Task<object> GetUser()
        {
            var returnable = await _dbcontext.Users.ToListAsync();
            return returnable;
            //return _service.GetAllCountries();
        }


        // PUT api/Values/PutUser/5
        [HttpPut, Route("PutUser/{id}")]
        public async Task<object> PutCountry(int id)
        {

            var model = new Country();

            object result = null; string message = "";
            if (model == null)
            {
                return BadRequest();
            }
            using (_dbcontext)
            {
                using (var _ctxTransaction = _dbcontext.Database.BeginTransaction())
                {
                    try
                    {
                        var entityUpdate = _dbcontext.Countries.FirstOrDefault(x => x.CountryId == id);
                        if (entityUpdate != null)
                        {
                            entityUpdate.CountryName = model.CountryName;
                            entityUpdate.CountryId = model.CountryId;
                            entityUpdate.Tractor = model.Tractor;

                            await _dbcontext.SaveChangesAsync();
                        }
                        _ctxTransaction.Commit();
                        message = "Entry Updated";
                    }
                    catch (Exception e)
                    {
                        _ctxTransaction.Rollback(); e.ToString();
                        message = "Entry Update Failed!!";
                    }

                    result = new
                    {
                        message
                    };
                }
            }
            return result;
        }


        // DELETE: api/Countriessss/5
        [HttpDelete, Route("api/deletethis/{id}")]
        public async Task<IActionResult> DeleteCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var country = await _dbcontext.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }
            //_service.DeleteCountry(country);
            _dbcontext.Countries.Remove(country);
            await _dbcontext.SaveChangesAsync();

            return Ok(country);
        }

        [HttpPut, Route("api/buyOneUnit/{id}")]
        public async Task<IActionResult> BuyOneUnit([FromRoute] int id, [FromBody] Country c)
        {

            var A = await _ibserv.buyU(id, c);
            return NoContent();
        }


        [HttpPut, Route("api/buyOneBuilding/{id}")]
        public async Task<IActionResult> BuyOneBuilding([FromRoute] int id, [FromBody] Country c)
        {

            await _ibserv.buyB(id,c);
            return NoContent();
            
        }


        [HttpGet, Route("api/getAllFor/{id}")]
        public IActionResult getAllFor(int id)
        {
            var owner = _dbcontext.Countries.Where(c => c.CountryId == id).FirstOrDefault();
            var countrylist = _dbcontext.Countries.ToList();
            var countrylistdto = new List<CountryDto>();
            for (var i = 0; i < countrylist.Count; i++) { countrylistdto.Add( new CountryDto(countrylist[i])); }

            var platoons = _dbcontext.Platoons
                .Include(A => A.Archers)
                .Include(A => A.Horsemans)
                .Include(A => A.Soldiers)
                .Where(P => P.Owner == owner).ToList();

            var platoonList = new List<PlatoonDto>();
            for (var i = 0; i < platoons.Count; i++)
            {
                platoonList.Add(new PlatoonDto(platoons[i]));

            }



            var pack = new PackedDetailsDto()
            {
                c = new CountryDto(owner),
                a = new ArcherDto(_dbcontext.Archers.Where(A => A.OwnerCountry == owner).FirstOrDefault()),
                h = new HorsemanDto(_dbcontext.Horsemans.Where(A => A.OwnerCountry == owner).FirstOrDefault()),
                s = new EliteDto(_dbcontext.Elites.Where(A => A.OwnerCountry == owner).FirstOrDefault()),
                f = new FarmDto(_dbcontext.Farms.Where(A => A.OwnerCountry == owner).FirstOrDefault()),
                b = new BarrackDto(_dbcontext.Barracks.Where(A => A.OwnerCountry == owner).FirstOrDefault()),
                p = platoonList,
                cs = countrylistdto,
        };

            

            return Ok(pack);
        }


    }
}
