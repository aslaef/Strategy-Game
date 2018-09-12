using Microsoft.AspNetCore.Mvc;
using Strategy_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.ServiceInterfaces
{
    public interface IStrategyService
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int id);

        void AddCountry(Country country);

        void DeleteCountry(Country country);

        Game DoOneRound();




    }
}
