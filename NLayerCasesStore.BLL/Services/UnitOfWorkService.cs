using AutoMapper;
using NLayerCasesStore.BLL.Interfaces;
using NLayerCasesStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.BLL.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private UserService userService;
        private OrderService orderService;
        private CaseService caseService;
        private BasketService basketService;

        public UnitOfWorkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public IUserService Users
        {
            get
            {
                if (userService == null)
                {
                    userService = new UserService(_unitOfWork, _mapper);
                }

                return userService;
            }
        }
        public IBasketService Baskets
        {
            get
            {
                if (basketService == null)
                {
                    basketService = new BasketService(_unitOfWork, _mapper);
                }

                return basketService;
            }
        }
        public ICaseService Cases
        {
            get
            {
                if (caseService == null)
                {
                    caseService = new CaseService(_unitOfWork, _mapper);
                }

                return caseService;
            }
        }

        public IOrderService Orders
        {
            get
            {
                if (orderService == null)
                {
                    orderService = new OrderService(_unitOfWork, _mapper);
                }

                return orderService;
            }
        }
    }
}
