using Strategy_game.Context;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Strategy_game.Services;
using Strategy_game.Models;
using Microsoft.Data.Sqlite;


namespace XUnitTestProject1
{
    public class Test2
    {

        //[Theory]
        //[InlineData(300, 140, 640, 10, 0, 15)]
        //public void UpgradeAlchemy(int x1, int x2, int x3, int x4, int x5, int x6)
        //{
        //    // In-memory database only exists while the connection is open
        //    var connection = new SqliteConnection("DataSource=:memory:");
        //    connection.Open();

        //    try
        //    {
        //        var options = new DbContextOptionsBuilder<ApplitactionDbContext>()
        //            .UseSqlite(connection)
        //            .Options;
        //        //var context = new ApplitactionDbContext(options);

        //        using (var context = new ApplitactionDbContext(options))
        //        {
        //            context.Database.EnsureCreated();
        //        }

        //        using (var context = new ApplitactionDbContext(options))
        //        {
        //            var g = new Strategy_game.Models.Game();
        //            var c = new Strategy_game.Models.Country() { CountryName = "zzzz", Gold = 500 };
        //            var a = new Strategy_game.Models.Archer() { OwnerCountry = c, Counter = 2 };
        //            var h = new Strategy_game.Models.Horseman() { OwnerCountry = c, Counter = 2 };
        //            var s = new Strategy_game.Models.Elite() { OwnerCountry = c, Counter = 2 };
        //            var f = new Strategy_game.Models.Farm() { OwnerCountry = c, Counter = 4 };
        //            var b = new Strategy_game.Models.Barrack() { OwnerCountry = c, Counter = 2 };

        //            context.Games.Add(g);
        //            context.Countries.Add(c);
        //            context.Archers.Add(a);
        //            context.Horsemans.Add(h);
        //            context.Elites.Add(s);
        //            context.Farms.Add(f);
        //            context.Barracks.Add(b);

        //            context.SaveChanges();
        //            var ch = context.Countries.FirstOrDefaultAsync(d => d.CountryName == "zzzz").Result;


        //        }

        //        using (var context = new ApplitactionDbContext(options))
        //        {

        //            var service = new StrategyService(context);
        //            service.DoOneRound();

        //            var from = context.Countries.FirstOrDefaultAsync(C => C.CountryName == "zzzz").Result;

        //            //(300,140,640,10,0,15)

        //            Assert.Equal(x2, from.Gold);

        //        }


        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //}

    }
}
