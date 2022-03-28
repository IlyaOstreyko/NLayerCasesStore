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
    internal class UserRepository : IRepository<UserDataModel>
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
            var users = _casesStoreContext.Users.Include(o => o.Orders);
            var usersDM = _mapper.Map<IEnumerable<UserDataModel>>(users);

            return usersDM;
        }

        public UserDataModel Get(int id)
        {
            var user = _casesStoreContext.Users.Find(id);
            var userDM = _mapper.Map<UserDataModel>(user);

            return userDM;
        }

        public void Create(UserDataModel userDM)
        {
            //var user = new User
            //{
            //    UserMail = userDM.UserMail,
            //    UserName = userDM.UserName,
            //    UserPassword = userDM.UserPassword,
            //    UserRole = "user"
            //};
            var user = _mapper.Map<User>(userDM);
            _casesStoreContext.Users.Add(user);
        }

        public void Update(UserDataModel userDM)
        {
            //var user = new User
            //{
            //    UserMail = userDM.UserMail,
            //    UserName = userDM.UserName,
            //    UserPassword = userDM.UserPassword,
            //    UserRole = "user",
            //    BasketId = userDM.BasketId
            //};
            var user = _mapper.Map<User>(userDM);
            _casesStoreContext.Entry(user).State = EntityState.Modified;
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
