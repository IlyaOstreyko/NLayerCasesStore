using NLayerCasesStore.DAL.DataModels;
using NLayerCasesStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<BasketDataModel> Baskets { get; }
        IRepository<OrderDataModel> Orders { get; }
        //IRepository<Admin> Admins { get; }
        IRepository<UserDataModel> Users { get; }
        IRepository<CaseDataModel> Cases { get; }
        void Save();
    }
}
