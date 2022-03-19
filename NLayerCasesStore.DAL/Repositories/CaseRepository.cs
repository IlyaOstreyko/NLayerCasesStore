using Microsoft.EntityFrameworkCore;
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
    public class CaseRepository : IRepository<Case>
    {
        private CasesStoreContext _casesStoreContext;

        public CaseRepository(CasesStoreContext casesStoreContext)
        {
            _casesStoreContext = casesStoreContext;
        }

        public IEnumerable<Case> GetAll()
        {
            return _casesStoreContext.Cases.Include(o => o.Orders);
        }

        public Case Get(int id)
        {
            return _casesStoreContext.Cases.Find(id);
        }

        public void Create(Case itemcase)
        {
            _casesStoreContext.Cases.Add(itemcase);
        }

        public void Update(Case itemcase)
        {
            _casesStoreContext.Entry(itemcase).State = EntityState.Modified;
        }
        public IEnumerable<Case> Find(Func<Case, bool> predicate)
        {
            return _casesStoreContext.Cases.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Case itemcase = _casesStoreContext.Cases.Find(id);
            if (itemcase != null)
                _casesStoreContext.Cases.Remove(itemcase);
        }
    }
}
