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
        private readonly CasesStoreContext _casesStoreContext;
        private UserRepository userRepository;
        private OrderRepository orderRepository;
        private CaseRepository caseRepository;
        private BasketRepository basketRepository;
        private readonly IMapper _mapper;

        public EFUnitOfWork(DbContextOptions<CasesStoreContext> options, IMapper mapper)
        {
            _casesStoreContext = new CasesStoreContext(options);
            _mapper = mapper;
            
        }
        public IUserRepository<UserDataModel> Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_casesStoreContext, _mapper);
                }

                return userRepository;
            }
        }
        public IBasketRepository Baskets
        {
            get
            {
                if (basketRepository == null)
                {
                    basketRepository = new BasketRepository(_casesStoreContext, _mapper);
                }
                    
                return basketRepository;
            }
        }
        public IRepository<CaseDataModel> Cases
        {
            get
            {
                if (caseRepository == null)
                {
                    caseRepository = new CaseRepository(_casesStoreContext, _mapper);
                }
                    
                return caseRepository;
            }
        }

        public IRepository<OrderDataModel> Orders
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(_casesStoreContext, _mapper);
                }
                    
                return orderRepository;
            }
        }

        public void Save()
        {
            _casesStoreContext.SaveChanges();
        }
    }
}
