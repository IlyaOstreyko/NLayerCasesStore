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
        private CasesStoreContext _casesStoreContext;
        private UserRepository userRepository;
        private OrderRepository orderRepository;
        private CaseRepository caseRepository;
        private BasketRepository basketRepository;

        public EFUnitOfWork(DbContextOptions<CasesStoreContext> options)
        {
            _casesStoreContext = new CasesStoreContext(options);
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_casesStoreContext);
                return userRepository;
            }
        }
        public IRepository<Basket> Baskets
        {
            get
            {
                if (basketRepository == null)
                    basketRepository = new BasketRepository(_casesStoreContext);
                return basketRepository;
            }
        }
        public IRepository<Case> Cases
        {
            get
            {
                if (caseRepository == null)
                    caseRepository = new CaseRepository(_casesStoreContext);
                return caseRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(_casesStoreContext);
                return orderRepository;
            }
        }

        public void Save()
        {
            _casesStoreContext.SaveChanges();
        }
    }
}
