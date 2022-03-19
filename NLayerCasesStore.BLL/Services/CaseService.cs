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

namespace NLayerCasesStore.BLL.Services
{
    public class CaseService : ICaseService
    {
        IUnitOfWork Database { get; set; }

        public CaseService(IUnitOfWork uow)
        {
            Database = uow;
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

        public CaseDTO GetCase(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id чехла", "");
            var caseItem = Database.Cases.Get(id.Value);
            if (caseItem == null)
                throw new ValidationException("Чехол не найден", "");

            return new CaseDTO { Company = caseItem.Company, Model = caseItem.Model, Color = caseItem.Color, Price = caseItem.Price };
        }
        public IEnumerable<CaseDTO> GetCases()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Case, CaseDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Case>, List<CaseDTO>>(Database.Cases.GetAll());
        }
    }
}
