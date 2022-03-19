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
    public class BasketRepository : IRepository<Basket>
    {
        private CasesStoreContext _casesStoreContext;

        public BasketRepository(CasesStoreContext casesStoreContext)
        {
            _casesStoreContext = casesStoreContext;
        }

        public IEnumerable<Basket> GetAll()
        {
            return _casesStoreContext.Baskets.Include(o => o.Cases);
        }

        public Basket Get(int id)
        {
            return _casesStoreContext.Baskets.Find(id);
        }

        public void Create(Basket itembasket)
        {
            _casesStoreContext.Baskets.Add(itembasket);
        }

        public void Update(Basket itembasket)
        {
            _casesStoreContext.Entry(itembasket).State = EntityState.Modified;
        }
        public IEnumerable<Basket> Find(Func<Basket, bool> predicate)
        {
            return _casesStoreContext.Baskets.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Basket itembasket = _casesStoreContext.Baskets.Find(id);
            if (itembasket != null)
                _casesStoreContext.Baskets.Remove(itembasket);
        }
    }
}
