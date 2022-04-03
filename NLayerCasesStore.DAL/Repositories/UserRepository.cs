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
    internal class UserRepository : IUserRepository<UserDataModel>
    {
        private CasesStoreContext _casesStoreContext;
        private readonly IMapper _mapper;

        public UserRepository(CasesStoreContext casesStoreContext, IMapper mapper)
        {
            _casesStoreContext = casesStoreContext;
            _mapper = _mapper;
        }

        public IEnumerable<UserDataModel> GetAll()
        {
            var users = _casesStoreContext.Users.ToList();
            var usersDM = _mapper.Map<IEnumerable<UserDataModel>>(users);
            return usersDM;
        }

        public UserDataModel Get(int id)
        {
            var user = _casesStoreContext.Users.Find(id);
            var userDM = _mapper.Map<UserDataModel>(user);
            return userDM;
        }
        public UserDataModel GetOnEmailAndPassword(string email, string password)
        {
            var user = _casesStoreContext.Users.FirstOrDefault(u => u.UserMail == email && u.UserPassword == password);
            var userDM = _mapper.Map<UserDataModel>(user);
            return userDM;
        }
        public void Create(UserDataModel userDM)
        {
            var user = _mapper.Map<User>(userDM);
            user.UserRole = "user";
            _casesStoreContext.Users.Add(user);
        }

        public void Update(UserDataModel userDM)
        {
            var user = _mapper.Map<User>(userDM);
            _casesStoreContext.Entry(user).State = EntityState.Modified;
        }
        public bool CheckEmail(string email)
        {
            var user = _casesStoreContext.Users.FirstOrDefault(u => u.UserMail == email);
            if (user is null)
            {
                return false;
            }
            return true;
        }
        public bool CheckLogin(string login)
        {
            var user = _casesStoreContext.Users.FirstOrDefault(u => u.UserName == login);
            if (user is null)
            {
                return false;
            }
            return true;
        }
        //public IEnumerable<UserDataModel> Find(Func<User, bool> predicate)
        //{
        //    return _casesStoreContext.Users.Where(predicate).ToList();
        //}
        public void Delete(int id)
        {
            User user = _casesStoreContext.Users.Find(id);
            if (user != null)
                _casesStoreContext.Users.Remove(user);
        }
    }
}
