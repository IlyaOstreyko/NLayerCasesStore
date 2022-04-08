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
    public class OrderRepository : IRepository<OrderDataModel>
    {
        private readonly CasesStoreContext _casesStoreContext;
        private readonly IMapper _mapper;

        public OrderRepository(CasesStoreContext casesStoreContext, IMapper mapper)
        {
            _casesStoreContext = casesStoreContext;
            _mapper = mapper;
        }

        public IEnumerable<OrderDataModel> GetAll()
        {
            var orders = _casesStoreContext.Orders.Include(o => o.Cases);
            var ordersDM = _mapper.Map<IEnumerable<OrderDataModel>>(orders);

            return ordersDM;
        }

        public OrderDataModel Get(int id)
        {
            var order = _casesStoreContext.Orders.Find(id);
            var orderDM = _mapper.Map<OrderDataModel>(order);

            return orderDM;
        }

        public void Create(OrderDataModel orderDM)
        {
            var order = _mapper.Map<Order>(orderDM);
            _casesStoreContext.Orders.Add(order);
        }

        public void Update(OrderDataModel orderDM)
        {
            var order = _mapper.Map<Order>(orderDM);
            _casesStoreContext.Entry(order).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Order order = _casesStoreContext.Orders.Find(id);

            if (order != null)
            {
                _casesStoreContext.Orders.Remove(order);
            }               
        }
    }
}
