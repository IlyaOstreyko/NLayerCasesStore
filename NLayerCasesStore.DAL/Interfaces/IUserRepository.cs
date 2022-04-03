using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.DAL.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T GetOnEmailAndPassword(string email, string password);
        bool CheckEmail(string email);
        bool CheckLogin(string login);
        //IEnumerable<T> Find(int IdDependent);
        //IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);

    }
}
