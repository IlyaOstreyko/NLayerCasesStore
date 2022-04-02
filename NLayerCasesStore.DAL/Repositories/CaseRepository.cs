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
    public class CaseRepository : IRepository<CaseDataModel>
    {
        private CasesStoreContext _casesStoreContext;
        private readonly IMapper _mapper;

        public CaseRepository(CasesStoreContext casesStoreContext, IMapper mapper)
        {
            _casesStoreContext = casesStoreContext;
            _mapper = mapper;
        }

        public IEnumerable<CaseDataModel> GetAll()
        {
            var cases = _casesStoreContext.Cases.ToList();
            var casesDM = _mapper.Map<IEnumerable<CaseDataModel>>(cases);

            return casesDM;
        }
        public CaseDataModel Get(int id)
        {
            var caseItem = _casesStoreContext.Cases.Find(id);
            var caseDM = _mapper.Map<CaseDataModel>(caseItem);

            return caseDM;
        }

        public void Create(CaseDataModel itemCaseDM)
        {
            //var itemCase = new Case
            //{
            //    Company = itemCaseDM.Company,
            //    Model = itemCaseDM.Model,
            //    Color = itemCaseDM.Color,
            //    Price = itemCaseDM.Price,
            //    CasesNumber = itemCaseDM.CasesNumber
            //};
            var itemCase = _mapper.Map<Case>(itemCaseDM);
            _casesStoreContext.Cases.Add(itemCase);
        }

        public void Update(CaseDataModel itemCaseDM)
        {
            var itemCase = _mapper.Map<Case>(itemCaseDM);
            _casesStoreContext.Entry(itemCase).State = EntityState.Modified;
        }
        //public IEnumerable<CaseDataModel> Find(Func<CaseDataModel, bool> predicate)
        //{
        //    var cases = _casesStoreContext.Cases.Where(predicate).ToList();
        //    var casesDM = _mapper.Map<IEnumerable<CaseDataModel>>(cases);

        //    return casesDM;
        //    //return _casesStoreContext.Cases.Where(predicate).ToList();
        //}
        public void Delete(int id)
        {
            Case itemcase = _casesStoreContext.Cases.Find(id);
            if (itemcase != null)
            {
                _casesStoreContext.Cases.Remove(itemcase);
            } 
        }
    }
}
