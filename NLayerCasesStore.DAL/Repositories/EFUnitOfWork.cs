using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLayerCasesStore.DAL.DataModels;
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
        private IMapper _mapper;

        public EFUnitOfWork(DbContextOptions<CasesStoreContext> options)
        {
            _casesStoreContext = new CasesStoreContext(options);
            
        }
        public IRepository<UserDataModel> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_casesStoreContext, _mapper);
                return userRepository;
            }
        }
        public IRepository<BasketDataModel> Baskets
        {
            get
            {
                if (basketRepository == null)
                    basketRepository = new BasketRepository(_casesStoreContext, _mapper);
                return basketRepository;
            }
        }
        public IRepository<CaseDataModel> Cases
        {
            get
            {
                if (caseRepository == null)
                    caseRepository = new CaseRepository(_casesStoreContext, _mapper);
                return caseRepository;
            }
        }

        public IRepository<OrderDataModel> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(_casesStoreContext, _mapper);
                return orderRepository;
            }
        }

        public void Save()
        {
            _casesStoreContext.SaveChanges();
        }
    }
}
