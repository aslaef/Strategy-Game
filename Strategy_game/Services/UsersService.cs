using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Strategy_game.Context;
using Strategy_game.Dto;
using Strategy_game.Helpers;
using Strategy_game.Models;
using Strategy_game.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_game.Services
{
    public class UsersService : IUsersService
    {
        private ApplitactionDbContext _dbcontext;
        private readonly AppSettings _appSettings;

        public UsersService(ApplitactionDbContext context, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

            _dbcontext = context;
        }

        public User Login(UserDto u)
        {
            
            var user = _dbcontext.Users.Include(U => U.OwnedCountry).Where(U => U.Name == u.Name && u.Pass == u.Pass).FirstOrDefault();
            var returned = user.OwnedCountry.CountryId;

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;


        }

        public bool RegisterUser(UserDto u)
        {
            var games = _dbcontext.Games.FirstOrDefault();
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
