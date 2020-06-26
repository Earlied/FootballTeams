using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using FootballTeams.DAL.Entities;

namespace FootballTeams.DAL.EF
{
    public class Context : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        static Context()
        {
            Database.SetInitializer<Context>(new StoreDbInitializer());
        }
        public Context(string connectionString)
            : base(connectionString)
        {
        }

    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context db)
        {
            db.Players.Add(new Player { Name = "Josh Jackson", Age = 20, Skill = "National League"});
            db.Players.Add(new Player { Name = "Fred Vahrman", Age = 21, Skill = "Novice" });
            db.Teams.Add(new Team { Name = "AAA", EstDate = new DateTime(2020,25,06), Skill = "National League"});
            db.Coaches.Add(new Coach { Name = "Tony Colman", Age =  55, Skill = "National League"});
            db.SaveChanges();
        }
    }
}