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
    public class UnitBuildingSetterService : IUnitBuildingSetterService
    {
        private ApplitactionDbContext _dbcontext;

        public UnitBuildingSetterService(ApplitactionDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Building> buyB(int id, Country c)
        {
            var C = _dbcontext.Countries.Where(c2 => c2.CountryId == c.CountryId).FirstOrDefault();

            var Building = _dbcontext.Buildings.Where(u => u.BuildingId == id).FirstOrDefault();

            if (Building.Builder == 0)
            {
                if (C.Gold >= Building.Price)
                {
                    C.Gold -= Building.Price;
                    Building.Builder = 5;
                    //Building.Counter += 1;
                    _dbcontext.Entry(C).State = EntityState.Modified;
                    _dbcontext.Entry(Building).State = EntityState.Modified;
                    await _dbcontext.SaveChangesAsync();
                    return Building;
                }
            }
            return Building;
        }

        public async Task<Unit> buyU(int id, Country c)
        {
            var C = _dbcontext.Countries.Where(c2 => c2.CountryId == c.CountryId).FirstOrDefault();

            var Unit = _dbcontext.Units.Where(u => u.UnitId == id).FirstOrDefault();

            if (C.Gold >= Unit.Price)
            {
                C.Gold -= Unit.Price;
                Unit.Counter += 1;
                
                await _dbcontext.SaveChangesAsync();
                return Unit;
            }
            return Unit;
        }

        public Archer getA(int id)
        {
            var tempCountry = _dbcontext.Countries.Where(c => c.CountryId == id).FirstOrDefault();
            if (tempCountry == null)
            {
                return null;
            }
            var a = _dbcontext.Archers.Where(ar => ar.OwnerCountry == tempCountry).FirstOrDefault();
            if (a == null)
            {
                return null;
            }
            if (a != null)
            {
                a.OwnerCountry = null;
            }

            return a;


        }

        public Barrack getB(int id)
        {
            var tempCountry = _dbcontext.Countries.Where(c => c.CountryId == id).FirstOrDefault();
            if (tempCountry == null)
            {
                return null;
            }
            var a = _dbcontext.Barracks.Where(ar => ar.OwnerCountry == tempCountry).FirstOrDefault();
            if (a == null)
            {
                return null;
            }
            if (a != null)
            {
                a.OwnerCountry = null;
            }

            return a;
        }

        public Farm getF(int id)
        {
            var tempCountry = _dbcontext.Countries.Where(c => c.CountryId == id).FirstOrDefault();
            if (tempCountry == null)
            {
                return null;
            }
            var a = _dbcontext.Farms.Where(ar => ar.OwnerCountry == tempCountry).FirstOrDefault();
            if (a == null)
            {
                return null;
            }
            if (a != null)
            {
                a.OwnerCountry = null;
            }

            return a;
        }

        public Horseman getH(int id)
        {
            var tempCountry = _dbcontext.Countries.Where(c => c.CountryId == id).FirstOrDefault();
            if (tempCountry == null)
            {
                return null;
            }
            var a = _dbcontext.Horsemans.Where(ar => ar.OwnerCountry == tempCountry).FirstOrDefault();
            if (a == null)
            {
                return null;
            }
            if (a != null)
            {
                a.OwnerCountry = null;
            }

            return a;
        }

        public Elite getS(int id)
        {
            var tempCountry = _dbcontext.Countries.Where(c => c.CountryId == id).FirstOrDefault();
            if (tempCountry == null)
            {
                return null;
            }
            var a = _dbcontext.Elites.Where(ar => ar.OwnerCountry == tempCountry).FirstOrDefault();
            if (a == null)
            {
                return null;
            }
            if (a != null)
            {
                a.OwnerCountry = null;
            }

            return a;
        }

        public async Task<Unit> postA(int id)
        {
            var country = _dbcontext.Countries.Where(c => c.CountryId == id).SingleOrDefault();
            
            var a = new Archer()
            {
                OwnerCountry = country
            };
            _dbcontext.Archers.Add(a);
            await _dbcontext.SaveChangesAsync();
            return a;
        }

        public async Task<Building> postB(int id)
        {
            var country = _dbcontext.Countries.Where(c => c.CountryId == id).SingleOrDefault();

            var a = new Barrack()
            {
                OwnerCountry = country
            };
            _dbcontext.Barracks.Add(a);
            await _dbcontext.SaveChangesAsync();
            return a;
        }

        public async Task<Building> postF(int id)
        {
            var country = _dbcontext.Countries.Where(c => c.CountryId == id).SingleOrDefault();

            var a = new Farm()
            {
                OwnerCountry = country
            };
            _dbcontext.Farms.Add(a);
            await _dbcontext.SaveChangesAsync();
            return a;
        }

        public async Task<Unit> postH(int id)
        {
            var country = _dbcontext.Countries.Where(c => c.CountryId == id).SingleOrDefault();

            var a = new Horseman()
            {
                OwnerCountry = country
            };
            _dbcontext.Horsemans.Add(a);
            await _dbcontext.SaveChangesAsync();
            return a;
        }

        public async Task<Unit> postS(int id)
        {
            var country = _dbcontext.Countries.Where(c => c.CountryId == id).SingleOrDefault();

            var a = new Elite()
            {
                OwnerCountry = country
            };
            _dbcontext.Elites.Add(a);
            await _dbcontext.SaveChangesAsync();
            return a;
        }

        public async Task<Unit> putA(int id)
        {
            var originalA = _dbcontext.Archers.Where(a1 => a1.UnitId == id).FirstOrDefault();
            if (originalA == null) { return null; }

            originalA.Counter += 1;
            _dbcontext.Entry(originalA).State = EntityState.Modified;

            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return originalA;
        }

        public async Task<Building> putB(int id)
        {
            var originalA = _dbcontext.Barracks.Where(a1 => a1.BuildingId == id).FirstOrDefault();
            if (originalA == null) { return null; }

            originalA.Counter += 1;
            _dbcontext.Entry(originalA).State = EntityState.Modified;

            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return originalA;
        }

        public async Task<Building> putF(int id)
        {
            var originalA = _dbcontext.Farms.Where(a1 => a1.BuildingId == id).FirstOrDefault();
            if (originalA == null) { return null; }

            originalA.Counter += 1;
            _dbcontext.Entry(originalA).State = EntityState.Modified;

            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return originalA;
        }

        public async Task<Unit> putH(int id)
        {
            var originalA = _dbcontext.Horsemans.Where(a1 => a1.UnitId == id).FirstOrDefault();
            if (originalA == null) { return null; }

            originalA.Counter += 1;
            _dbcontext.Entry(originalA).State = EntityState.Modified;

            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return originalA;
        }

        public async Task<Unit> putS(int id)
        {
            var originalA = _dbcontext.Elites.Where(a1 => a1.UnitId == id).FirstOrDefault();
            if (originalA == null) { return null; }

            originalA.Counter += 1;
            _dbcontext.Entry(originalA).State = EntityState.Modified;

            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return originalA;
        }
    }
}
