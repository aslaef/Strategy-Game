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
        public bool RegisterUser(UserDto u)
        {
            var archer = new Archer();
            archer.Counter = 10;
            var c = new Country()
            {
                CountryName = u.CountryName,
                Gold = 1500,
                
                
            };
            var user = new User()
            {
                Name = u.Name,
                Password = u.PassWord,
                OwnedCountry = c,
                Score = 0,
            };
            




            _dbcontext.Users.Add(user);

            _dbcontext.SaveChanges();

            return true;
        }
    }
}
