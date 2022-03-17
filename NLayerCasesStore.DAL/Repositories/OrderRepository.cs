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
    public class OrderRepository : IRepository<Order>
    {
        private CasesStoreContext _casesStoreContext;

        public OrderRepository(CasesStoreContext casesStoreContext)
        {
            _casesStoreContext = casesStoreContext;
        }

        public IEnumerable<Order> GetAll()
        {
            return _casesStoreContext.Orders.Include(o => o.Cases);
        }

        public Order Get(int id)
        {
            return _casesStoreContext.Orders.Find(id);
        }

        public void Create(Order order)
        {
            _casesStoreContext.Orders.Add(order);
        }

        public void Update(Order order)
        {
            _casesStoreContext.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return _casesStoreContext.Orders.Include(o => o.Cases).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Order order = _casesStoreContext.Orders.Find(id);
            if (order != null)
                _casesStoreContext.Orders.Remove(order);
        }
    }
}
