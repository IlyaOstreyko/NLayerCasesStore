using NLayerCasesStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Basket> Baskets { get; }
        IRepository<Order> Orders { get; }
        //IRepository<Admin> Admins { get; }
        IRepository<User> Users { get; }
        IRepository<Case> Cases { get; }
        void Save();
    }
}
