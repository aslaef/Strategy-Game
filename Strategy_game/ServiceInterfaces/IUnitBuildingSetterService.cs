using Strategy_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.ServiceInterfaces
{
    public interface IUnitBuildingSetterService
    {
        Archer getA(int id);
        Horseman getH(int id);
        Elite getS(int id);
        Farm getF(int id);
        Barrack getB(int id);


        Task<Unit> postA(int id);
        Task<Unit> postH(int id);
        Task<Unit> postS(int id);
        Task<Building> postF(int id);
        Task<Building> postB(int id);

        Task<Unit> putA(int id);
        Task<Unit> putH(int id);
        Task<Unit> putS(int id);
        Task<Building> putF(int id);
        Task<Building> putB(int id);

        Task<Unit> buyU(int id, Country c);
        Task<Building> buyB(int id, Country c);

    }
}
