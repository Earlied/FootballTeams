using System;
using FootballTeams.DAL.EF;
using FootballTeams.DAL.Interfaces;
using FootballTeams.DAL.Entities;

namespace FootballTeams.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private Context db;
        private PlayerRepository playerRepository;
        private TeamRepository orderRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new MobileContext(connectionString);
        }
        public IRepository<Phone> Phones
        {
            get
            {
                if (phoneRepository == null)
                    phoneRepository = new PhoneRepository(db);
                return phoneRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}