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
    internal class UserRepository : IRepository<User>
    {
        private CasesStoreContext _casesStoreContext;

        public UserRepository(CasesStoreContext casesStoreContext)
        {
            _casesStoreContext = casesStoreContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _casesStoreContext.Users.Include(o => o.Orders);
        }

        public User Get(int id)
        {
            return _casesStoreContext.Users.Find(id);
        }

        public void Create(User user)
        {
            _casesStoreContext.Users.Add(user);
        }

        public void Update(User user)
        {
            _casesStoreContext.Entry(user).State = EntityState.Modified;
        }
        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return _casesStoreContext.Users.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            User user = _casesStoreContext.Users.Find(id);
            if (user != null)
                _casesStoreContext.Users.Remove(user);
        }
    }
}
