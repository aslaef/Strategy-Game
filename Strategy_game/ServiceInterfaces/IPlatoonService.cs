using Strategy_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.ServiceInterfaces
{
    public interface IPlatoonService
    {
        Platoon GetPlatoon(int id);

        List<Platoon> GetPlatoons();

        void PutPlatoon(Platoon p);

        void PostPlatoon(int id);

        void AddUnitToPlatoon(Unit u);

        void DeleteUnitFromPlatoon(Unit u);

        void ReturnUnitFromPlatoon(Unit u);

        Platoon putUnitToPlatoon(int platoonId, int platoonUnitId);
        Platoon putHorsemanInPlatoon(int id, int platoonId);
        Platoon putSoldierInPlatoon(int id, int platoonId);

        Platoon AttackCountry(int fromId, int toId);
        Platoon setIntent(int fromId, int toId);
    }
}
