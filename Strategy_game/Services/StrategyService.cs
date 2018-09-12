using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Strategy_game.Context;
using Strategy_game.Models;
using Strategy_game.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Services
{
    public class StrategyService : IStrategyService
    {
        private ApplitactionDbContext _dbcontext;

        public StrategyService(ApplitactionDbContext context)
        {
            _dbcontext = context;
        }

        public async void AddCountry(Country country)
        {
            _dbcontext.Add(country);
            _dbcontext.SaveChanges();
        }




        public void DeleteCountry(Country c)
        {
            _dbcontext.Countries.Remove(c);
        }

        public Game DoOneRound()
        {
            var G = _dbcontext.Games.FirstOrDefault();
            if(G != null) { 
            G.RoundNumber += 1;
            _dbcontext.Entry(G).State = EntityState.Modified;

            var countries = _dbcontext.Countries.ToList();
            foreach (Country c in countries)
            {
                var archer = _dbcontext.Archers.Where(a => a.OwnerCountry == c).FirstOrDefault();
                var horse = _dbcontext.Horsemans.Where(a => a.OwnerCountry == c).FirstOrDefault();
                var soldier = _dbcontext.Elites.Where(a => a.OwnerCountry == c).FirstOrDefault();
                var farm = _dbcontext.Farms.Where(a => a.OwnerCountry == c).FirstOrDefault();
                var barrack = _dbcontext.Barracks.Where(a => a.OwnerCountry == c).FirstOrDefault();
                if(farm != null && archer != null && horse != null && soldier != null) { 
                        var Plusgold = farm.Counter * farm.Population;
                        var Minusgold = archer.Counter * archer.Salary + horse.Counter * horse.Salary + soldier.Counter * soldier.Salary;
                        var Pluspotatoes = farm.Counter * farm.PotatoesPerRound;
                        var MinusPotatoes = archer.Food * archer.Counter + horse.Food * horse.Counter + soldier.Food * soldier.Counter;


                        if (farm.Builder > 0) {
                            farm.Builder--;
                            if(farm.Builder == 0)
                            {
                                farm.Counter += 1;
                            }
                        }
                        if (barrack.Builder > 0) {
                            barrack.Builder--;
                            if (barrack.Builder == 0)
                            {
                                barrack.Counter += 1;
                            }
                        }
                        var FinaplPlusGold = Plusgold - Minusgold;
                        var FinalPlusPotatoe = Pluspotatoes - MinusPotatoes;
                        if (c.Tractor) { FinalPlusPotatoe += (int)(FinalPlusPotatoe * 0.1); }
                        if (c.Combine) { FinalPlusPotatoe += (int)(FinalPlusPotatoe * 0.15); }
                        if (c.Alchemy) { FinaplPlusGold += (int)(FinaplPlusGold * 0.3); }

                        c.Gold += FinaplPlusGold;
                        c.Potatoes += FinalPlusPotatoe;

                        _dbcontext.Entry(c).State = EntityState.Modified;
                        _dbcontext.Entry(farm).State = EntityState.Modified;
                        _dbcontext.Entry(barrack).State = EntityState.Modified;
                }
                    
                    
                    





                }

                foreach (Country c in countries)
                {
                    var p = AttackCountry(c.CountryId);
                }

                _dbcontext.SaveChanges();
            }
            return G;
        }


        public List<Platoon> AttackCountry(int fromId)
        {
            
            var from = _dbcontext.Countries.Where(c => c.CountryId == fromId).FirstOrDefault();
            var PList = _dbcontext.Platoons
                .Include(A => A.Archers)
                .Include(A => A.Horsemans)
                .Include(A => A.Soldiers)
                .Where(p => p.Owner == from).ToList();

            for(var iter=0; iter<PList.Count; iter++)
            {
                var P = PList[iter];
            
                if(P.Intent != 0) { 
                    var toId = P.Intent;
                    var to = _dbcontext.Countries.Where(c => c.CountryId == toId).FirstOrDefault();
                    var a1 = _dbcontext.Archers.Where(c => c.OwnerCountry == to).FirstOrDefault();
                    var h1 = _dbcontext.Horsemans.Where(c => c.OwnerCountry == to).FirstOrDefault();
                    var s1 = _dbcontext.Elites.Where(c => c.OwnerCountry == to).FirstOrDefault();


            

                    var enemysoldiercount = a1.Def*a1.Counter + a1.Def*h1.Counter + s1.Def*s1.Counter;
                    var friendlysoldiercount = P.Archers.Atk * P.Archers.Counter + P.Horsemans.Atk * P.Horsemans.Counter + P.Soldiers.Atk* P.Soldiers.Counter;
                    if (to.Wall) { enemysoldiercount += (int)(enemysoldiercount * 0.2); } // wall
                    if (to.Tactican) { enemysoldiercount += (int)(enemysoldiercount * 0.1); } //tactic atk + def

                    if (from.Tactican) { friendlysoldiercount += (int)(friendlysoldiercount * 0.1); } //tactic atk + def
                    if(from.Commander) { friendlysoldiercount += (int)(friendlysoldiercount * 0.2); } //operation rebirth atk

                    if (friendlysoldiercount > enemysoldiercount)
                    {

                        to.Gold = to.Gold / 2;
                        to.Potatoes = to.Potatoes / 2;
                        from.Gold += to.Gold;
                        from.Potatoes += to.Potatoes;
                        a1.Counter = a1.Counter - (int)(a1.Counter * 0.1);
                        h1.Counter = h1.Counter - (int)(h1.Counter * 0.1);
                        s1.Counter = s1.Counter - (int)(s1.Counter * 0.1);

                        _dbcontext.Entry(from).State = EntityState.Modified;
                        _dbcontext.Entry(to).State = EntityState.Modified;
                        _dbcontext.Entry(a1).State = EntityState.Modified;
                        _dbcontext.Entry(h1).State = EntityState.Modified;
                        _dbcontext.Entry(s1).State = EntityState.Modified;


                    }
                    else
                    {
                        P.Archers.Counter -= (int)(P.Archers.Counter * 0.1);
                        P.Horsemans.Counter -= (int)(P.Horsemans.Counter * 0.1);
                        P.Soldiers.Counter -= (int)(P.Soldiers.Counter * 0.1);

                        _dbcontext.Entry(P).State = EntityState.Modified;


                    }
                    P.Intent = 0;
                }
                _dbcontext.SaveChanges();

            }
            return PList;
        }



        public IEnumerable<Country> GetAllCountries()
        {
            return _dbcontext.Countries
                .Include(a => a.Units)
                .Include(a => a.Buildings).ToList();
                
        }

        public Country GetCountryById(int id)
        {
            return _dbcontext.Countries.Where(c => c.CountryId == id).SingleOrDefault();
        }

        public Horseman getHorsemanFor(int id,Country tempCountry)
        {
            return _dbcontext.Horsemans.Where(ar => ar.OwnerCountry == tempCountry).FirstOrDefault();
        }



    }
}
