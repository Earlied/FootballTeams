using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FootballTeams.DAL.Entities;
using FootballTeams.DAL.EF;
using FootballTeams.DAL.Interfaces;

namespace FootballTeams.DAL.Repositories
{
    public class TeamRepository : IRepository<Team>
    {
        private Context db;

        public TeamRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<Team> GetAll()
        {
            return db.Teams.Include(o => o.Players);
        }

        public Team Get(int TeamId)
        {
            return db.Teams.Find(TeamId);
        }

        public void Create(Team team)
        {
            db.Teams.Add(team);
        }

        public void Update(Team team)
        {
            db.Entry(team).State = EntityState.Modified;
        }
        public IEnumerable<Team> Find(Func<Team, Boolean> predicate)
        {
            return db.Teams.Include(o => o.Players).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Team team = db.Teams.Find(id);
            if (team != null)
                db.Teams.Remove(team);
        }
    }
}