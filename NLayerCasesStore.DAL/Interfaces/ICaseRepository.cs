using NLayerCasesStore.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.DAL.Interfaces
{
    public interface ICaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetCasesInBasketFromEmail(string email);
        IEnumerable<T> GetCasesInBasketInStock(string email);
        IEnumerable<BasketCaseDataModel> GetBasketCasesFromEmail(string email);
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
