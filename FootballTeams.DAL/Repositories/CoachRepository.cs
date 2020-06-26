using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FootballTeams.DAL.Entities;
using FootballTeams.DAL.EF;
using FootballTeams.DAL.Interfaces;

namespace FootballTeams.DAL.Repositories
{
    public class CoachRepository : IRepository<Coach>
    {
        private Context db;

        public CoachRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<Coach> GetAll()
        {
            return db.Coaches.Include(o => o.Teams);
        }

        public Coach Get(int CoachId)
        {
            return db.Coaches.Find(CoachId);
        }

        public void Create(Coach coach)
        {
            db.Coaches.Add(coach);
        }

        public void Update(Coach coach)
        {
            db.Entry(coach).State = EntityState.Modified;
        }
        public IEnumerable<Coach> Find(Func<Coach, Boolean> predicate)
        {
            return db.Coaches.Include(o => o.Teams).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Coach coach = db.Coaches.Find(id);
            if (coach != null)
                db.Coaches.Remove(coach);
        }
    }
}