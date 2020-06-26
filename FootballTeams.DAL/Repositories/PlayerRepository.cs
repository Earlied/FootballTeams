using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using FootballTeams.DAL.Entities;
using FootballTeams.DAL.Interfaces;
using FootballTeams.DAL.EF;

namespace FootballTeams.DAL.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        private Context db;

        public PlayerRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<Player> GetAll()
        {
            return db.Players;
        }

        public Player Get(int PlayerId)
        {
            return db.Players.Find(PlayerId);
        }

        public void Create(Player player)
        {
            db.Players.Add(player);
        }

        public void Update(Player player)
        {
            db.Entry(player).State = EntityState.Modified;
        }

        public IEnumerable<Player> Find(Func<Player, Boolean> predicate)
        {
            return db.Players.Where(predicate).ToList();
        }

        public void Delete(int PLayerId)
        {
            Player player = db.Players.Find(PLayerId);
            if (player != null)
                db.Players.Remove(player);
        }
    }
}