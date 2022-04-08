using AutoMapper;
using NLayerCasesStore.BLL.DTO;
using NLayerCasesStore.BLL.Interfaces;
using NLayerCasesStore.DAL.DataModels;
using NLayerCasesStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.BLL.Services
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BasketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddCaseInBasket(string userEmail, int idCase)
        {
            var idUser = _unitOfWork.Users.GetIdOnEmail(userEmail);
            var caseDM = _unitOfWork.Cases.Get(idCase);
            _unitOfWork.Baskets.AddCaseInBasket(idUser, caseDM);
            _unitOfWork.Save();
        }
    }
}
