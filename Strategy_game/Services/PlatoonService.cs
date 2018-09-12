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
    public class PlatoonService : IPlatoonService
    {
        private ApplitactionDbContext _dbcontext;

        public PlatoonService(ApplitactionDbContext context)
        {
            _dbcontext = context;
        }

        public void AddUnitToPlatoon(Unit u)
        {
            throw new NotImplementedException();
        }

        public Platoon setIntent(int fromId, int toId)
        {
            //var from = _dbcontext.Countries.Where(c => c.CountryId == fromId).FirstOrDefault();

            var P = _dbcontext.Platoons
                .Include(A => A.Archers)
                .Include(A => A.Horsemans)
                .Include(A => A.Soldiers)
                .Include(A => A.Owner)
                .SingleOrDefault(p => p.PlatoonId == fromId);

            P.Intent = toId;

            _dbcontext.SaveChanges();
            return P;
        }

        public Platoon AttackCountry(int fromId, int toId)
        {
            var from = _dbcontext.Countries.Where(c => c.CountryId == fromId).FirstOrDefault();


            var to = _dbcontext.Countries.Where(c => c.CountryId == toId).FirstOrDefault();
            var a1 = _dbcontext.Archers.Where(c => c.OwnerCountry == to).FirstOrDefault();
            var h1 = _dbcontext.Horsemans.Where(c => c.OwnerCountry == to).FirstOrDefault();
            var s1 = _dbcontext.Elites.Where(c => c.OwnerCountry == to).FirstOrDefault();


            var P = _dbcontext.Platoons
                .Include(A => A.Archers)
                .Include(A => A.Horsemans)
                .Include(A => A.Soldiers)
                .Where(p => p.Owner == from).FirstOrDefault();

            var enemysoldiercount = a1.Counter + h1.Counter + s1.Counter;
            var friendlysoldiers = P.Archers.Counter + P.Horsemans.Counter + P.Soldiers.Counter;
            if (friendlysoldiers > enemysoldiercount)
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

            _dbcontext.SaveChanges();


            return P;
        }

        public void DeleteUnitFromPlatoon(Unit u)
        {
            throw new NotImplementedException();
        }

        public Platoon GetPlatoon(int id)
        {
            var c = _dbcontext.Countries.Where(C => C.CountryId == id).FirstOrDefault();
            var P = _dbcontext.Platoons
                .Include(A => A.Archers)
                .Include(A => A.Horsemans)
                .Include(A => A.Soldiers)
                .Where(p => p.Owner == c).FirstOrDefault();



            return P;
        }

        public List<Platoon> GetPlatoons()
        {
            throw new NotImplementedException();
        }

        public void PostPlatoon(int id)
        {
            var Owner = _dbcontext.Countries.Where(c => c.CountryId == id).FirstOrDefault();
            var p = new Platoon()
            {
                Owner = Owner,
                Archers = new Archer(),
                Horsemans = new Horseman(),
                Soldiers = new Elite()
            };
            _dbcontext.Platoons.Add(p);
            _dbcontext.SaveChanges();
        }

        public Platoon putArcherInPlatoon(int id, int platoonId)
        {
            var c = _dbcontext.Countries.Where(A => A.CountryId == id).FirstOrDefault();
            var a = _dbcontext.Archers.Where(A => A.OwnerCountry == c).FirstOrDefault();
            var p = _dbcontext.Platoons
                .Include(A => A.Archers)
                .Include(A => A.Horsemans)
                .Include(A => A.Soldiers)
                .Where(A => A.PlatoonId == platoonId).FirstOrDefault();
            var a2 = _dbcontext.Archers.Where(A => A == p.Archers).FirstOrDefault();
            if (a.Counter > 0)
            {
                a.Counter -= 1;
                a2.Counter += 1;

                _dbcontext.Entry(a).State = EntityState.Modified;
                _dbcontext.Entry(a2).State = EntityState.Modified;

                _dbcontext.SaveChanges();
            }
            return p;

        }

        public Platoon putHorsemanInPlatoon(int id, int platoonId)
        {
            var c = _dbcontext.Countries.Where(A => A.CountryId == id).FirstOrDefault();
            var a = _dbcontext.Horsemans.Where(A => A.OwnerCountry == c).FirstOrDefault();
            var p = _dbcontext.Platoons
                .Include(A => A.Archers)
                .Include(A => A.Horsemans)
                .Include(A => A.Soldiers)
                .Where(A => A.PlatoonId == platoonId).FirstOrDefault();
            var a2 = _dbcontext.Horsemans.Where(A => A == p.Horsemans).FirstOrDefault();
            if (a.Counter > 0)
            {
                a.Counter -= 1;
                a2.Counter += 1;

                _dbcontext.Entry(a).State = EntityState.Modified;
                _dbcontext.Entry(a2).State = EntityState.Modified;

                _dbcontext.SaveChanges();
            }
            return p;
        }

        public void PutPlatoon(Platoon p)
        {
            _dbcontext.Entry(p).State = EntityState.Modified;
        }

        public Platoon putSoldierInPlatoon(int id, int platoonId)
        {
            var c = _dbcontext.Countries.Where(A => A.CountryId == id).FirstOrDefault();
            var a = _dbcontext.Elites.Where(A => A.OwnerCountry == c).FirstOrDefault();
            var p = _dbcontext.Platoons
                .Include(A => A.Archers)
                .Include(A => A.Horsemans)
                .Include(A => A.Soldiers)
                .Where(A => A.PlatoonId == platoonId).FirstOrDefault();
            var a2 = _dbcontext.Elites.Where(A => A == p.Soldiers).FirstOrDefault();
            if (a.Counter > 0)
            {
                a.Counter -= 1;
                a2.Counter += 1;

                _dbcontext.Entry(a).State = EntityState.Modified;
                _dbcontext.Entry(a2).State = EntityState.Modified;

                _dbcontext.SaveChanges();
            }
            return p;
        }

        public void ReturnUnitFromPlatoon(Unit u)
        {
            throw new NotImplementedException();
        }
    }
}
