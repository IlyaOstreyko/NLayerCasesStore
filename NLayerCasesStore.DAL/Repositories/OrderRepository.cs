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
        public IEnumerable<OrderDataModel> GetUserOrders(string userEmail, string status)
        {
            if (userEmail == "all")
            {
                var orders = _casesStoreContext.Orders.Where(a => a.Status == status)
                    .Include(o => o.Cases);
                var ordersDM = _mapper.Map<IEnumerable<OrderDataModel>>(orders);
                return ordersDM;
            }
            else
            {
                var user = _casesStoreContext.Users
                .Include(o => o.Orders.Where(a => a.Status == status))
                .ThenInclude(o => o.Cases)
                .FirstOrDefault(u => u.UserMail == userEmail);

                var ordersDM = _mapper.Map<IEnumerable<OrderDataModel>>(user.Orders);
                return ordersDM;
            }            
        }

        public OrderDataModel Get(int id)
        {
            var order = _casesStoreContext.Orders.Find(id);
            var orderDM = _mapper.Map<OrderDataModel>(order);

            return orderDM;
        }

        public void Create(string userEmail, string address, IEnumerable<CaseDataModel> casesDM)
        {
            _casesStoreContext.ChangeTracker.Clear();
            var user = _casesStoreContext.Users
                .Include(o => o.Basket)
                .ThenInclude(o => o.Cases)
                .FirstOrDefault(u => u.UserMail == userEmail);

            var cases = user.Basket.Cases.Where(c => c.CasesNumber > 0);

            var order = new Order { Address = address, Cases = cases.ToList(), DataOrder = DateTime.Now, User = user, Status = "open"};

            foreach (var c in cases)
            {
                c.CasesNumber--;
            }

            user.Basket.Cases.RemoveAll(b => b.CasesNumber > 0);

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
        public void CloseOrder(int? id)
        {
            _casesStoreContext.ChangeTracker.Clear();
            Order order = _casesStoreContext.Orders.Find(id);

            if (order != null)
            {
                order.Status = "close";
                order.DataClose = DateTime.Now;
            }
        }
    }
}
