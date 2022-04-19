using AutoMapper;
using NLayerCasesStore.BLL.DTO;
using NLayerCasesStore.BLL.Infrastructure;
using NLayerCasesStore.BLL.Interfaces;
using NLayerCasesStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerCasesStore.DAL.Interfaces;
using NLayerCasesStore.DAL.DataModels;

namespace NLayerCasesStore.BLL.Services
{
    public class CaseService : ICaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<CaseDTO> GetCasesInBasketFromEmail(string email)
        {
            var casesDM = _unitOfWork.Cases.GetCasesInBasketFromEmail(email);
            var casesDto = _mapper.Map<IEnumerable<CaseDTO>>(casesDM);
            _unitOfWork.Save();
            return casesDto;
        }
        public IEnumerable<BasketCaseDTO> GetBasketCasesFromEmail(string email)
        {
            var basketCasesDM = _unitOfWork.Cases.GetBasketCasesFromEmail(email);
            var basketCasesDto = _mapper.Map<IEnumerable<BasketCaseDTO>>(basketCasesDM);
            _unitOfWork.Save();
            return basketCasesDto;
        }

        public IEnumerable<CaseDTO> GetCasesInBasketInStock(string email)
        {
            var casesDM = _unitOfWork.Cases.GetCasesInBasketInStock(email);
            var casesDto = _mapper.Map<IEnumerable<CaseDTO>>(casesDM);
            return casesDto;
        }
        public void CreateCase(CaseDTO caseDto)
        {
            _unitOfWork.Cases.Create(_mapper.Map<CaseDataModel>(caseDto));
            _unitOfWork.Save();
        }

        public void DeleteCase(int id)
        {
            _unitOfWork.Cases.Delete(id);
            _unitOfWork.Save();
        }
        public CaseDTO GetCase(int id)
        {
            var caseItem = _unitOfWork.Cases.Get(id);

            if (caseItem == null)
            {
                throw new ValidationException("", "Чехол не найден");
            }

            var caseDto = _mapper.Map<CaseDTO>(caseItem);

            return caseDto;
        }
        public IEnumerable<CaseDTO> GetCases()
        {
            var cases = _unitOfWork.Cases.GetAll();
            var casesDM = _mapper.Map<IEnumerable<CaseDTO >>(cases);

            return casesDM;
        }

        public void UpdateCase(CaseDTO caseDto)
        {
            _unitOfWork.Cases.Update(_mapper.Map<CaseDataModel>(caseDto));
            _unitOfWork.Save();
        }
    }
}
