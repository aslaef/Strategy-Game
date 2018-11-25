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
    public class UnitTest1
    {










        [Theory]
        [InlineData(true, 1204, "tractor")]
        [InlineData(false, 1140, "tractor")]
        [InlineData(true, 1236, "combine")]
        [InlineData(false, 1140, "combine")]
        public void UpgradeForPotatoes(bool x1, int x2, string x3)
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplitactionDbContext>()
                    .UseSqlite(connection)
                    .Options;
                //var context = new ApplitactionDbContext(options);

                using (var context = new ApplitactionDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new ApplitactionDbContext(options))
                {

                    var c = new Strategy_game.Models.Country()
                    {
                        CountryName = "zzzz",
                        Potatoes = 500,

                    };

                    var g = new Strategy_game.Models.Game();

                    if (x3 == "tractor")
                    {
                        c.Tractor = x1;
                    }
                    else
                    {
                        c.Combine = x1;

                    }

                    var a = new Strategy_game.Models.Archer() { OwnerCountry = c, Counter = 2 };
                    var h = new Strategy_game.Models.Horseman() { OwnerCountry = c, Counter = 2 };
                    var s = new Strategy_game.Models.Elite() { OwnerCountry = c, Counter = 2 };
                    var f = new Strategy_game.Models.Farm() { OwnerCountry = c, Counter = 4 };
                    var b = new Strategy_game.Models.Barrack() { OwnerCountry = c, Counter = 2 };

                    context.Games.Add(g);
                    context.Countries.Add(c);
                    context.Archers.Add(a);
                    context.Horsemans.Add(h);
                    context.Elites.Add(s);
                    context.Farms.Add(f);
                    context.Barracks.Add(b);

                    context.SaveChanges();


                }

                using (var context = new ApplitactionDbContext(options))
                {

                    var service = new StrategyService(context);
                    service.DoOneRound();

                    var from = context.Countries.FirstOrDefaultAsync(C => C.CountryName == "zzzz").Result;



                    Assert.Equal(x2, from.Potatoes);

                }


            }
            finally
            {
                connection.Close();
            }

        }

        [Theory]
        [InlineData(true, 682)]
        [InlineData(false, 640)]
        public void UpgradeAlchemy(bool x1, int x2)
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplitactionDbContext>()
                    .UseSqlite(connection)
                    .Options;
                //var context = new ApplitactionDbContext(options);

                using (var context = new ApplitactionDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new ApplitactionDbContext(options))
                {
                    var g = new Strategy_game.Models.Game();
                    var c = new Strategy_game.Models.Country
                    {
                        CountryName = "zzzz",
                        Gold = 500,
                        Alchemy = x1
                    };
                    var a = new Strategy_game.Models.Archer { OwnerCountry = c, Counter = 2 };
                    var h = new Strategy_game.Models.Horseman { OwnerCountry = c, Counter = 2 };
                    var s = new Strategy_game.Models.Elite { OwnerCountry = c, Counter = 2 };
                    var f = new Strategy_game.Models.Farm { OwnerCountry = c, Counter = 4 };
                    var b = new Strategy_game.Models.Barrack { OwnerCountry = c, Counter = 2 };

                    context.Games.Add(g);
                    context.Countries.Add(c);
                    context.Archers.Add(a);
                    context.Horsemans.Add(h);
                    context.Elites.Add(s);
                    context.Farms.Add(f);
                    context.Barracks.Add(b);

                    context.SaveChanges();


                }

                using (var context = new ApplitactionDbContext(options))
                {

                    var service = new StrategyService(context);
                    service.DoOneRound();

                    var from = context.Countries
                        .FirstOrDefaultAsync(C => C.CountryName == "zzzz").Result;



                    Assert.Equal(x2, from.Gold);

                }


            }
            finally
            {
                connection.Close();
            }

        }

        [Theory]
        [InlineData(300, 140, 640, 10, 0, 15)]
        public void WinnerCountry(int x1, int x2, int x3, int x4, int x5, int x6)
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplitactionDbContext>()
                    .UseSqlite(connection)
                    .Options;
                //var context = new ApplitactionDbContext(options);

                using (var context = new ApplitactionDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new ApplitactionDbContext(options))
                {
                    var g = new Strategy_game.Models.Game();
                    var c = new Strategy_game.Models.Country() { CountryName = "zzzz" };
                    var a = new Strategy_game.Models.Archer() { OwnerCountry = c, Counter = 2 };
                    var h = new Strategy_game.Models.Horseman() { OwnerCountry = c, Counter = 2 };
                    var s = new Strategy_game.Models.Elite() { OwnerCountry = c, Counter = 2 };
                    var f = new Strategy_game.Models.Farm() { OwnerCountry = c, Counter = 4 };
                    var b = new Strategy_game.Models.Barrack() { OwnerCountry = c, Counter = 2 };




                    var c2 = new Strategy_game.Models.Country() { CountryName = "cccc" };
                    var a2 = new Strategy_game.Models.Archer() { OwnerCountry = c2, Counter = 10 };
                    var h2 = new Strategy_game.Models.Horseman() { OwnerCountry = c2, Counter = 10 };
                    var s2 = new Strategy_game.Models.Elite() { OwnerCountry = c2, Counter = 10 };
                    var f2 = new Strategy_game.Models.Farm() { OwnerCountry = c2, Counter = 12 };
                    var b2 = new Strategy_game.Models.Barrack() { OwnerCountry = c2, Counter = 2 };



                    context.Games.Add(g);
                    context.Countries.Add(c);
                    context.Archers.Add(a);
                    context.Horsemans.Add(h);
                    context.Elites.Add(s);
                    context.Farms.Add(f);
                    context.Barracks.Add(b);


                    context.Countries.Add(c2);
                    context.Archers.Add(a2);
                    context.Horsemans.Add(h2);
                    context.Elites.Add(s2);
                    context.Farms.Add(f2);
                    context.Barracks.Add(b2);
                    context.SaveChanges();
                    var ch = context.Countries.FirstOrDefaultAsync(d => d.CountryName == "zzzz").Result;
                    var ch2 = context.Countries.FirstOrDefaultAsync(d => d.CountryName == "cccc").Result;

                    //var casd = context.Countries.FirstOrDefaultAsync();
                    var p = new Platoon()
                    {
                        Owner = ch,
                        Archers = new Archer() { Counter = 15 },
                        Horsemans = new Horseman() { Counter = 15 },
                        Soldiers = new Elite() { Counter = 15 },
                        Intent = ch2.CountryId,

                    };
                    context.Platoons.Add(p);
                    Assert.NotEqual(0, ch.CountryId);
                    context.SaveChanges();
                }

                using (var context = new ApplitactionDbContext(options))
                {

                    var service = new StrategyService(context);
                    service.DoOneRound();


                    var p = context.Platoons
                        .Include(pts => pts.Archers)
                        .Include(pts => pts.Horsemans)
                        .Include(pts => pts.Soldiers)
                        .Include(pts => pts.Owner).FirstOrDefaultAsync().Result;



                    //service.DoOneRound();
                    var from = context.Countries.FirstOrDefaultAsync(C => C.CountryName == "zzzz").Result;
                    var to = context.Countries.FirstOrDefaultAsync(C => C.CountryName == "cccc").Result;

                    var ra = context.Archers.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "cccc").Result;
                    var rh = context.Horsemans.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "cccc").Result;
                    var rs = context.Elites.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "cccc").Result;

                    //(300,140,640,10,0,15)
                    Assert.Equal(x1, to.Gold);
                    Assert.Equal(x2, from.Gold);

                    Assert.Equal(x3, from.Potatoes);
                    Assert.NotEqual(x3, to.Potatoes);

                    Assert.NotEqual(x3, to.Potatoes);

                    Assert.Equal(x4, ra.Counter);
                    Assert.Equal(x4, rh.Counter);
                    Assert.Equal(x4, rs.Counter);
                    Assert.Equal(x5, p.Intent);
                    Assert.NotEqual(x6, p.Archers.Counter);
                    Assert.NotEqual(x6, p.Horsemans.Counter);
                    Assert.NotEqual(x6, p.Soldiers.Counter);

                }


            }
            finally
            {
                connection.Close();
            }

        }

        [Theory]
        [InlineData(540, 140, "wall", false)]
        [InlineData(540, 140, "wall", true)]
        [InlineData(540, 140, "strategy", false)]
        [InlineData(270, 410, "strategy", true)]
        [InlineData(540, 140, "tactician", false)]
        [InlineData(540, 140, "tacticianDef", true)]
        [InlineData(270, 410, "tacticianAtk", true)]
        public void WarUpgrades(int x1, int x2, string upgrade, bool val)
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplitactionDbContext>()
                    .UseSqlite(connection)
                    .Options;
                //var context = new ApplitactionDbContext(options);

                using (var context = new ApplitactionDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new ApplitactionDbContext(options))
                {
                    var g = new Strategy_game.Models.Game();
                    var c = new Strategy_game.Models.Country() { CountryName = "zzzz" };
                    var a = new Strategy_game.Models.Archer() { OwnerCountry = c, Counter = 2 };
                    var h = new Strategy_game.Models.Horseman() { OwnerCountry = c, Counter = 2 };
                    var s = new Strategy_game.Models.Elite() { OwnerCountry = c, Counter = 2 };
                    var f = new Strategy_game.Models.Farm() { OwnerCountry = c, Counter = 4 };
                    var b = new Strategy_game.Models.Barrack() { OwnerCountry = c, Counter = 2 };




                    var c2 = new Strategy_game.Models.Country() { CountryName = "cccc" };
                    var a2 = new Strategy_game.Models.Archer() { OwnerCountry = c2, Counter = 2 };
                    var h2 = new Strategy_game.Models.Horseman() { OwnerCountry = c2, Counter = 2 };
                    var s2 = new Strategy_game.Models.Elite() { OwnerCountry = c2, Counter = 2 };
                    var f2 = new Strategy_game.Models.Farm() { OwnerCountry = c2, Counter = 12 };
                    var b2 = new Strategy_game.Models.Barrack() { OwnerCountry = c2, Counter = 2 };

                    if (upgrade == "wall") { c2.Wall = val; }
                    if (upgrade == "strategy") { c.Commander = val; }
                    if (upgrade == "tacticianDef") { c2.Tactican = val; }
                    if (upgrade == "tacticianAtk") { c.Tactican = val; }
                    if (upgrade == "tactician") { c2.Tactican = val; }

                    context.Games.Add(g);
                    context.Countries.Add(c);
                    context.Archers.Add(a);
                    context.Horsemans.Add(h);
                    context.Elites.Add(s);
                    context.Farms.Add(f);
                    context.Barracks.Add(b);


                    context.Countries.Add(c2);
                    context.Archers.Add(a2);
                    context.Horsemans.Add(h2);
                    context.Elites.Add(s2);
                    context.Farms.Add(f2);
                    context.Barracks.Add(b2);
                    context.SaveChanges();
                    var ch = context.Countries.FirstOrDefaultAsync(d => d.CountryName == "zzzz").Result;
                    var ch2 = context.Countries.FirstOrDefaultAsync(d => d.CountryName == "cccc").Result;

                    //var casd = context.Countries.FirstOrDefaultAsync();
                    var p = new Platoon()
                    {
                        Owner = ch,
                        Archers = new Archer() { Counter = 6 },
                        Horsemans = new Horseman() { Counter = 6 },
                        Soldiers = new Elite() { Counter = 6 },
                        Intent = ch2.CountryId,

                    };
                    context.Platoons.Add(p);
                    Assert.NotEqual(0, ch.CountryId);
                    context.SaveChanges();
                }

                using (var context = new ApplitactionDbContext(options))
                {

                    var service = new StrategyService(context);
                    service.DoOneRound();


                    var p = context.Platoons
                        .Include(pts => pts.Archers)
                        .Include(pts => pts.Horsemans)
                        .Include(pts => pts.Soldiers)
                        .Include(pts => pts.Owner).FirstOrDefaultAsync().Result;



                    //service.DoOneRound();
                    var from = context.Countries.FirstOrDefaultAsync(C => C.CountryName == "zzzz").Result;
                    var to = context.Countries.FirstOrDefaultAsync(C => C.CountryName == "cccc").Result;

                    var ra = context.Archers.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "cccc").Result;
                    var rh = context.Horsemans.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "cccc").Result;
                    var rs = context.Elites.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "cccc").Result;

                    //(300,140,640,10,0,15)
                    Assert.Equal(x1, to.Gold);
                    Assert.Equal(x2, from.Gold);

                    Assert.Equal(0, p.Intent);

                }


            }
            finally
            {
                connection.Close();
            }

        }

        [Theory]
        [InlineData(94, 640)]
        public void LoserCountry(int x, int y)
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplitactionDbContext>()
                    .UseSqlite(connection)
                    .Options;
                //var context = new ApplitactionDbContext(options);

                using (var context = new ApplitactionDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new ApplitactionDbContext(options))
                {
                    var g = new Strategy_game.Models.Game();
                    var c = new Strategy_game.Models.Country() { CountryName = "zzzz" };
                    var a = new Strategy_game.Models.Archer() { OwnerCountry = c, Counter = 2 };
                    var h = new Strategy_game.Models.Horseman() { OwnerCountry = c, Counter = 2 };
                    var s = new Strategy_game.Models.Elite() { OwnerCountry = c, Counter = 2 };
                    var f = new Strategy_game.Models.Farm() { OwnerCountry = c, Counter = 4 };
                    var b = new Strategy_game.Models.Barrack() { OwnerCountry = c, Counter = 2 };




                    var c2 = new Strategy_game.Models.Country() { CountryName = "cccc" };
                    var a2 = new Strategy_game.Models.Archer() { OwnerCountry = c2, Counter = 10 };
                    var h2 = new Strategy_game.Models.Horseman() { OwnerCountry = c2, Counter = 10 };
                    var s2 = new Strategy_game.Models.Elite() { OwnerCountry = c2, Counter = 10 };
                    var f2 = new Strategy_game.Models.Farm() { OwnerCountry = c2, Counter = 12 };
                    var b2 = new Strategy_game.Models.Barrack() { OwnerCountry = c2, Counter = 2 };



                    context.Games.Add(g);
                    context.Countries.Add(c);
                    context.Archers.Add(a);
                    context.Horsemans.Add(h);
                    context.Elites.Add(s);
                    context.Farms.Add(f);
                    context.Barracks.Add(b);


                    context.Countries.Add(c2);
                    context.Archers.Add(a2);
                    context.Horsemans.Add(h2);
                    context.Elites.Add(s2);
                    context.Farms.Add(f2);
                    context.Barracks.Add(b2);
                    context.SaveChanges();
                    var ch = context.Countries.FirstOrDefaultAsync(d => d.CountryName == "zzzz").Result;
                    var ch2 = context.Countries.FirstOrDefaultAsync(d => d.CountryName == "cccc").Result;

                    //var casd = context.Countries.FirstOrDefaultAsync();
                    var p = new Platoon()
                    {
                        Owner = ch,
                        Archers = new Archer() { Counter = 150 },
                        Horsemans = new Horseman() { Counter = 150 },
                        Soldiers = new Elite() { Counter = 150 },
                        Intent = ch2.CountryId,

                    };
                    context.Platoons.Add(p);
                    Assert.NotEqual(0, ch.CountryId);
                    context.SaveChanges();
                }

                using (var context = new ApplitactionDbContext(options))
                {

                    var service = new StrategyService(context);
                    service.DoOneRound();


                    var p = context.Platoons
                        .Include(pts => pts.Archers)
                        .Include(pts => pts.Horsemans)
                        .Include(pts => pts.Soldiers)
                        .Include(pts => pts.Owner).FirstOrDefaultAsync().Result;



                    //service.DoOneRound();
                    var from = context.Countries.FirstOrDefaultAsync(C => C.CountryName == "zzzz").Result;
                    var to = context.Countries.FirstOrDefaultAsync(C => C.CountryName == "cccc").Result;

                    var ra = context.Archers.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "cccc").Result;
                    var rh = context.Horsemans.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "cccc").Result;
                    var rs = context.Elites.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "cccc").Result;


                    Assert.Equal(150, to.Gold);
                    Assert.Equal(290, from.Gold);

                    Assert.Equal(1440, from.Potatoes);
                    Assert.Equal(800, to.Potatoes);

                    Assert.Equal(9, ra.Counter);
                    Assert.Equal(9, rh.Counter);
                    Assert.Equal(9, rs.Counter);
                    Assert.Equal(0, p.Intent);
                    Assert.Equal(150, p.Archers.Counter);
                    Assert.Equal(150, p.Horsemans.Counter);
                    Assert.Equal(150, p.Soldiers.Counter);

                }


            }
            finally
            {
                connection.Close();
            }

        }


        [Fact]
        public void PlatoonPut()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplitactionDbContext>()
                    .UseSqlite(connection)
                    .Options;
                //var context = new ApplitactionDbContext(options);

                using (var context = new ApplitactionDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new ApplitactionDbContext(options))
                {
                    var g = new Strategy_game.Models.Game();
                    var c = new Strategy_game.Models.Country() { CountryName = "zzzz" };
                    var a = new Strategy_game.Models.Archer() { OwnerCountry = c, Counter = 2 };
                    var h = new Strategy_game.Models.Horseman() { OwnerCountry = c, Counter = 2 };
                    var s = new Strategy_game.Models.Elite() { OwnerCountry = c, Counter = 2 };
                    var f = new Strategy_game.Models.Farm() { OwnerCountry = c, Counter = 4 };
                    var b = new Strategy_game.Models.Barrack() { OwnerCountry = c, Counter = 2 };







                    context.Games.Add(g);
                    context.Countries.Add(c);
                    context.Archers.Add(a);
                    context.Horsemans.Add(h);
                    context.Elites.Add(s);
                    context.Farms.Add(f);
                    context.Barracks.Add(b);



                    context.SaveChanges();
                    var ch = context.Countries.FirstOrDefaultAsync(d => d.CountryName == "zzzz").Result;

                    //var casd = context.Countries.FirstOrDefaultAsync();
                    var p = new Platoon()
                    {
                        Owner = ch,
                        Archers = new Archer() { Counter = 150 },
                        Horsemans = new Horseman() { Counter = 150 },
                        Soldiers = new Elite() { Counter = 150 },

                    };
                    context.Platoons.Add(p);
                    context.SaveChanges();
                }

                using (var context = new ApplitactionDbContext(options))
                {

                    var service = new PlatoonService(context);



                    var p = context.Platoons
                        .Include(pts => pts.Archers)
                        .Include(pts => pts.Horsemans)
                        .Include(pts => pts.Soldiers)
                        .Include(pts => pts.Owner).FirstOrDefaultAsync().Result;



                    //service.DoOneRound();
                    var from = context.Countries.FirstOrDefaultAsync(C => C.CountryName == "zzzz").Result;

                    var ra = context.Archers.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "zzzz").Result;
                    var rh = context.Horsemans.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "zzzz").Result;
                    var rs = context.Elites.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "zzzz").Result;

                    service.putUnitToPlatoon(from.CountryId, p.PlatoonId);
                    service.putHorsemanInPlatoon(from.CountryId, p.PlatoonId);
                    service.putSoldierInPlatoon(from.CountryId, p.PlatoonId);

                    Assert.Equal(1, ra.Counter);
                    Assert.Equal(1, rh.Counter);
                    Assert.Equal(1, rs.Counter);

                    //Assert.Equal(0, p.Intent);
                    Assert.Equal(151, p.Archers.Counter);
                    Assert.Equal(151, p.Horsemans.Counter);
                    Assert.Equal(151, p.Soldiers.Counter);

                }


            }
            finally
            {
                connection.Close();
            }

        }





        [Theory]
        [InlineData("archer")]
        [InlineData("horseman")]
        [InlineData("soldier")]
        public async void ArcherAdd(string unitsel)
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplitactionDbContext>()
                    .UseSqlite(connection)
                    .Options;
                //var context = new ApplitactionDbContext(options);

                using (var context = new ApplitactionDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new ApplitactionDbContext(options))
                {
                    var g = new Strategy_game.Models.Game();
                    var c = new Strategy_game.Models.Country() { CountryName = "zzzz", Gold = 1000 };
                    var a = new Strategy_game.Models.Archer() { OwnerCountry = c, Counter = 2 };
                    var h = new Strategy_game.Models.Horseman() { OwnerCountry = c, Counter = 2 };
                    var s = new Strategy_game.Models.Elite() { OwnerCountry = c, Counter = 2 };
                    var f = new Strategy_game.Models.Farm() { OwnerCountry = c, Counter = 4 };
                    var b = new Strategy_game.Models.Barrack() { OwnerCountry = c, Counter = 2 };



                    context.Games.Add(g);
                    context.Countries.Add(c);
                    context.Archers.Add(a);
                    context.Horsemans.Add(h);
                    context.Elites.Add(s);
                    context.Farms.Add(f);
                    context.Barracks.Add(b);



                    context.SaveChanges();
                    var ch = context.Countries.FirstOrDefaultAsync(d => d.CountryName == "zzzz").Result;

                    //var casd = context.Countries.FirstOrDefaultAsync();
                    var p = new Platoon()
                    {
                        Owner = ch,
                        Archers = new Archer() { Counter = 150 },
                        Horsemans = new Horseman() { Counter = 150 },
                        Soldiers = new Elite() { Counter = 150 },

                    };
                    context.Platoons.Add(p);
                    context.SaveChanges();
                }

                using (var context = new ApplitactionDbContext(options))
                {
                    var from = context.Countries.FirstOrDefaultAsync(C => C.CountryName == "zzzz").Result;

                    var ra = context.Archers.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "zzzz").Result;
                    var rh = context.Horsemans.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "zzzz").Result;
                    var rs = context.Elites.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "zzzz").Result;
                    var service = new UnitBuildingSetterService(context);
                    if (unitsel == "archer")
                    {
                        await service.buyU(ra.UnitId, from);

                    }
                    if (unitsel == "horseman")
                    {
                        await service.buyU(rh.UnitId, from);

                        
                    }
                    if (unitsel == "soldier")
                    {
                        await service.buyU(rs.UnitId, from);

                        
                    }
                }


                using (var context = new ApplitactionDbContext(options))
                {

                    var service = new UnitBuildingSetterService(context);


                    //service.DoOneRound();
                    var from = context.Countries.FirstOrDefaultAsync(C => C.CountryName == "zzzz").Result;

                    var ra = context.Archers.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "zzzz").Result;
                    var rh = context.Horsemans.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "zzzz").Result;
                    var rs = context.Elites.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "zzzz").Result;

                    if (unitsel == "archer")
                    {

                        Assert.Equal(3, ra.Counter);

                        Assert.NotEqual(1000, from.Gold);
                    }
                    if (unitsel == "horseman")
                    {

                        Assert.Equal(3, rh.Counter);

                        Assert.NotEqual(1000, from.Gold);
                    }
                    if (unitsel == "soldier")
                    {

                        Assert.Equal(3, rs.Counter);

                        Assert.NotEqual(1000, from.Gold);
                    }
                }


            }
            finally
            {
                connection.Close();
            }

        }





        [Theory]
        [InlineData("Farm")]
        [InlineData("Barrack")]
        public async void Building(string unitsel)
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<ApplitactionDbContext>()
                    .UseSqlite(connection)
                    .Options;
                //var context = new ApplitactionDbContext(options);

                using (var context = new ApplitactionDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new ApplitactionDbContext(options))
                {
                    var g = new Strategy_game.Models.Game();
                    var c = new Strategy_game.Models.Country() { CountryName = "zzzz", Gold = 1000 };
                    var a = new Strategy_game.Models.Archer() { OwnerCountry = c, Counter = 2 };
                    var h = new Strategy_game.Models.Horseman() { OwnerCountry = c, Counter = 2 };
                    var s = new Strategy_game.Models.Elite() { OwnerCountry = c, Counter = 2 };
                    var f = new Strategy_game.Models.Farm() { OwnerCountry = c, Counter = 4 };
                    var b = new Strategy_game.Models.Barrack() { OwnerCountry = c, Counter = 2 };



                    context.Games.Add(g);
                    context.Countries.Add(c);
                    context.Archers.Add(a);
                    context.Horsemans.Add(h);
                    context.Elites.Add(s);
                    context.Farms.Add(f);
                    context.Barracks.Add(b);



                    context.SaveChanges();
                    var ch = context.Countries.FirstOrDefaultAsync(d => d.CountryName == "zzzz").Result;

                    //var casd = context.Countries.FirstOrDefaultAsync();
                    var p = new Platoon()
                    {
                        Owner = ch,
                        Archers = new Archer() { Counter = 150 },
                        Horsemans = new Horseman() { Counter = 150 },
                        Soldiers = new Elite() { Counter = 150 },

                    };
                    context.Platoons.Add(p);
                    context.SaveChanges();
                }

                using (var context = new ApplitactionDbContext(options))
                {

                    var service = new UnitBuildingSetterService(context);
                    var service_strat = new StrategyService(context);

                    //service.DoOneRound();
                    var from = context.Countries.FirstOrDefaultAsync(C => C.CountryName == "zzzz").Result;

                    var resultfarm = context.Farms.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "zzzz").Result;
                    var resultbarrack = context.Barracks.Include(Ra => Ra.OwnerCountry).FirstOrDefaultAsync(C => C.OwnerCountry.CountryName == "zzzz").Result;

                    if (unitsel == "Farm")
                    {
                        await service.buyB(resultfarm.BuildingId, from);

                        Assert.Equal(4, resultfarm.Counter);
                        Assert.Equal(5, resultfarm.Builder);

                        Assert.Equal(1000 - 200, from.Gold);
                        service_strat.DoOneRound();
                        service_strat.DoOneRound();

                        service_strat.DoOneRound();

                        service_strat.DoOneRound();
                        service_strat.DoOneRound();
                        Assert.Equal(0, resultfarm.Builder);
                        Assert.Equal(5, resultfarm.Counter);



                    }
                    if (unitsel == "Barrack")
                    {
                        await service.buyB(resultbarrack.BuildingId, from);

                        Assert.Equal(2, resultbarrack.Counter);
                        Assert.Equal(5, resultbarrack.Builder);

                        Assert.Equal(1000 - 1000, from.Gold);
                        service_strat.DoOneRound();
                        service_strat.DoOneRound();

                        service_strat.DoOneRound();

                        service_strat.DoOneRound();
                        service_strat.DoOneRound();
                        Assert.Equal(0, resultbarrack.Builder);
                        Assert.Equal(3, resultbarrack.Counter);
                    }
                }


            }
            finally
            {
                connection.Close();
            }

        }



    }
}
