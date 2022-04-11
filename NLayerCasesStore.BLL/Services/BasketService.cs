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

        public void AddCaseInBasket(string userEmail, CaseDTO caseDto)
        {
            var idUser = _unitOfWork.Users.GetIdOnEmail(userEmail);
            var caseDM = _mapper.Map<CaseDataModel>(caseDto);
            _unitOfWork.Baskets.AddCaseInBasket(idUser, caseDM);
            _unitOfWork.Save();
        }

        public void RemoveCaseFromBasket(string userEmail, int caseId)
        {
            var idUser = _unitOfWork.Users.GetIdOnEmail(userEmail);
            _unitOfWork.Baskets.RemoveCaseFromBasket(idUser, caseId);
            _unitOfWork.Save();
        }
        public void ClearBasket(string userEmail)
        {
            var idUser = _unitOfWork.Users.GetIdOnEmail(userEmail);
            _unitOfWork.Baskets.ClearBasket(idUser);
            _unitOfWork.Save();
        }
    }
}
