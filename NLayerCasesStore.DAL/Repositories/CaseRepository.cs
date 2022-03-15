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
        private CasesStoreContext db;

        public CaseRepository(CasesStoreContext context)
        {
            this.db = context;
        }

        public IEnumerable<Case> GetAll()
        {
            return db.Cases.Include(o => o.Orders);
        }

        public Case Get(int id)
        {
            return db.Cases.Find(id);
        }

        public void Create(Case itemcase)
        {
            db.Cases.Add(itemcase);
        }

        public void Update(Case itemcase)
        {
            db.Entry(itemcase).State = EntityState.Modified;
        }
        public IEnumerable<Case> Find(Func<Case, Boolean> predicate)
        {
            return db.Cases.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Case itemcase = db.Cases.Find(id);
            if (itemcase != null)
                db.Cases.Remove(itemcase);
        }
    }
}
