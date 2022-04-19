using NLayerCasesStore.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetUserOrders(string userEmail, string status);
        T Get(int id);
        void Create(string userEmail, string address, IEnumerable<CaseDataModel> casesDM);
        void CloseOrder(int? id);
        void Update(T item);
        void Delete(int id);
    }
}
