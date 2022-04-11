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
        private readonly CasesStoreContext _casesStoreContext;
        private readonly IMapper _mapper;

        public CaseRepository(CasesStoreContext casesStoreContext, IMapper mapper)
        {
            _casesStoreContext = casesStoreContext;
            _mapper = mapper;
        }

        public IEnumerable<CaseDataModel> GetAll()
        {
            var cases = _casesStoreContext.Cases.AsNoTracking().ToList();
            var casesDM = _mapper.Map<IEnumerable<CaseDataModel>>(cases);

            return casesDM;
        }
        public CaseDataModel Get(int id)
        {
            var caseItem = _casesStoreContext.Cases.Find(id);
            var caseDM = _mapper.Map<CaseDataModel>(caseItem);

            return caseDM;
        }

        public void Create(CaseDataModel caseDM)
        {
            var itemCase = _mapper.Map<Case>(caseDM);
            _casesStoreContext.Cases.Add(itemCase);
        }

        public void Update(CaseDataModel caseDM)
        {
            var itemCase = _mapper.Map<Case>(caseDM);
            _casesStoreContext.Entry(itemCase).State = EntityState.Modified;
        }
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
