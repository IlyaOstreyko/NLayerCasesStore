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
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public CaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //public void MakeCase(CaseDTO caseDto)
        //{
        //    Case itemCase = Database.Cases.Get(caseDto.CaseId);
        //    if (caseDto == null)
        //        throw new ValidationException("Чехол не найден", "");
        //    Case case = new Case
        //    {
        //        Date = DateTime.Now,
        //        Address = orderDto.Address,
        //        PhoneId = phone.Id,
        //        Sum = sum,
        //        PhoneNumber = orderDto.PhoneNumber
        //    };
        //    Database.Cases.Create(case);
        //    Database.Save();
        //}

        public CaseDTO GetCase(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id чехла", "");
            var caseItem = _unitOfWork.Cases.Get(id);

            if (caseItem == null)
            {
                throw new ValidationException("", "Чехол не найден");
            }                
            return _mapper.Map<CaseDTO>(caseItem);
            //return new CaseDTO { Company = caseItem.Company, Model = caseItem.Model, Color = caseItem.Color, Price = caseItem.Price };

        }
        public IEnumerable<CaseDTO> GetCases()
        {
            var cases = _unitOfWork.Cases.GetAll();
            var caseDtos = _mapper.Map<IEnumerable<CaseDTO>>(cases);

            return caseDtos;
        }
    }
}
