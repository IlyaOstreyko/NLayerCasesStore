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
        IBasketRepository Baskets { get; }
        IRepository<OrderDataModel> Orders { get; }
        IUserRepository<UserDataModel> Users { get; }
        IRepository<CaseDataModel> Cases { get; }
        void Save();
    }
}
