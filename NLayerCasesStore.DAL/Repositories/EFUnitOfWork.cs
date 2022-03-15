using Microsoft.EntityFrameworkCore;
using NLayerCasesStore.DAL.EF;
using NLayerCasesStore.DAL.Entities;
using NLayerCasesStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private CasesStoreContext db;
        private UserRepository userRepository;
        private OrderRepository orderRepository;
        private CaseRepository caseRepository;
        private BasketRepository basketRepository;

        public EFUnitOfWork(DbContextOptions<CasesStoreContext> options)
        {
            db = new CasesStoreContext(options);
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public IRepository<Basket> Baskets
        {
            get
            {
                if (basketRepository == null)
                    basketRepository = new BasketRepository(db);
                return basketRepository;
            }
        }
        public IRepository<Case> Cases
        {
            get
            {
                if (caseRepository == null)
                    caseRepository = new CaseRepository(db);
                return caseRepository;
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
