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
        private CasesStoreContext db;

        public BasketRepository(CasesStoreContext context)
        {
            this.db = context;
        }

        public IEnumerable<Basket> GetAll()
        {
            return db.Baskets.Include(o => o.Cases);
        }

        public Basket Get(int id)
        {
            return db.Baskets.Find(id);
        }

        public void Create(Basket itembasket)
        {
            db.Baskets.Add(itembasket);
        }

        public void Update(Basket itembasket)
        {
            db.Entry(itembasket).State = EntityState.Modified;
        }
        public IEnumerable<Basket> Find(Func<Basket, Boolean> predicate)
        {
            return db.Baskets.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Basket itembasket = db.Baskets.Find(id);
            if (itembasket != null)
                db.Baskets.Remove(itembasket);
        }
    }
}
