using Microsoft.EntityFrameworkCore;
using Strategy_game.Context;
using Strategy_game.Dto;
using Strategy_game.Models;
using Strategy_game.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Services
{
    public class UsersService : IUsersService
    {
        private ApplitactionDbContext _dbcontext;

        public UsersService(ApplitactionDbContext context)
        {
            _dbcontext = context;
        }

        public int Login(UserDto u)
        {
            
            var userCountry = _dbcontext.Users.Include(user => user.OwnedCountry).Where(user => user.Name == u.Name && u.Pass == u.Pass).FirstOrDefault();
            var returned = userCountry.OwnedCountry.CountryId;
            return returned;
        }

        public bool RegisterUser(UserDto u)
        {
            var games = _dbcontext.Games;
            if(games == null)
            {
                _dbcontext.Games.Add(new Game {RoundNumber = 1 });
            }





            var c = new Country()
            {
                CountryName = u.CountryName,
                Gold = 1500,
                
                
            };

            var archer = new Archer();
            archer.OwnerCountry = c;
            archer.Counter = 10;
            _dbcontext.Units.Add(archer);
            var horseman = new Horseman();
            horseman.OwnerCountry = c;
            _dbcontext.Units.Add(horseman);
            var soldier = new Elite();
            soldier.OwnerCountry = c;
            _dbcontext.Units.Add(soldier);

            var farm = new Farm();
            farm.OwnerCountry = c;
            _dbcontext.Buildings.Add(farm);
            var barrack = new Barrack();
            barrack.OwnerCountry = c;
            barrack.Counter = 1;
            _dbcontext.Buildings.Add(barrack);


            var user = new User()
            {
                Name = u.Name,
                Password = u.Pass,
                OwnedCountry = c,
                Score = 0,
            };



            _dbcontext.Countries.Add(c);

            _dbcontext.Users.Add(user);

            _dbcontext.SaveChanges();

            return true;
        }

        public List<UserDto> usersScore()
        {
            return _dbcontext.Users.Select(u => new UserDto { Name = u.Name, Score = u.Score }).ToList();
        }
    }
}
