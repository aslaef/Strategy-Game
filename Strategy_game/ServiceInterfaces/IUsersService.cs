using Strategy_game.Dto;
using Strategy_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.ServiceInterfaces
{
    public interface IUsersService
    {
        bool RegisterUser(UserDto u);
        int Login(UserDto u);

        List<UserDto> usersScore();
    }
}
