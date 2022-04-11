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
        private readonly CasesStoreContext _casesStoreContext;
        private readonly IMapper _mapper;

        public UserRepository(CasesStoreContext casesStoreContext, IMapper mapper)
        {
            _casesStoreContext = casesStoreContext;
            _mapper = mapper;
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
        public int GetIdOnEmail(string email)
        {
            var user = _casesStoreContext.Users.FirstOrDefault(u => u.UserMail == email);

            return user.UserId;
        }
        public IEnumerable<CaseDataModel> GetCasesInBasketFromEmail(string email)
        {
            var user = _casesStoreContext.Users.FirstOrDefault(u => u.UserMail == email);
            _casesStoreContext.Entry(user).Reference(u => u.Basket).Load();
            var basket = user.Basket;
            _casesStoreContext.Entry(basket).Collection(c => c.Cases).Load();
            var cases = basket.Cases;
            var casesDM = _mapper.Map<IEnumerable<CaseDataModel>>(cases);
            return casesDM;
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
        public void Delete(int id)
        {
            User user = _casesStoreContext.Users.Find(id);

            if (user != null)
            {
                _casesStoreContext.Users.Remove(user);
            }
        }
    }
}
