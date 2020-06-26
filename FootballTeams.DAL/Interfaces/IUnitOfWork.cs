using FootballTeams.DAL.Entities;
using FootballTeams.DAL.Interfaces;
using System;

namespace FootballTeams.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Player> Players { get; }
        IRepository<Team> Teams { get; }
        IRepository<Coach> Coaches { get; }
        void Save();
    }
}