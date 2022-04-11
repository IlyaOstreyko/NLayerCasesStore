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
    internal class BasketRepository : IBasketRepository
    {
        private readonly CasesStoreContext _casesStoreContext;
        private readonly IMapper _mapper;

        public BasketRepository(CasesStoreContext casesStoreContext, IMapper mapper)
        {
            _casesStoreContext = casesStoreContext;
            _mapper = mapper;
        }

        public void Create(int idUser)
        {
            var basket = new Basket {UserId = idUser };
            _casesStoreContext.Baskets.Add(basket);
            //var user = _casesStoreContext.Users.Find(idUser);
            //user.BasketId = basket.BasketId;
            _casesStoreContext.SaveChanges();
        }
        public void AddCaseInBasket(int idUser, CaseDataModel caseDM)
        {
            int count = _casesStoreContext.Cases.Local.Count;
            _casesStoreContext.ChangeTracker.Clear();
            count = _casesStoreContext.Cases.Local.Count;

            var itemCase = _mapper.Map<Case>(caseDM);
            var basket = _casesStoreContext.Baskets.FirstOrDefault(b => b.UserId == idUser);

            if (basket is null)
            {
                Create(idUser);
            }

            basket = _casesStoreContext.Baskets.FirstOrDefault(b => b.UserId == idUser);
            basket.Cases.Add(itemCase);
        }
        public void RemoveCaseFromBasket(int idUser, int caseId)
        {
            var basket = _casesStoreContext.Baskets.FirstOrDefault(b => b.UserId == idUser);
            _casesStoreContext.Entry(basket).Collection(c => c.Cases).Load();
            var itemCase = basket.Cases.FirstOrDefault(x => x.CaseId == caseId);
            basket.Cases.Remove(itemCase);
        }
        
        public void ClearBasket(int idUser)
        {
            var basket = _casesStoreContext.Baskets.FirstOrDefault(b => b.UserId == idUser);
            _casesStoreContext.Entry(basket).Collection(c => c.Cases).Load();
            basket.Cases.Clear();
        }

        public void DeleteCasesInBasket(List<CaseDataModel> casesDM)
        {
            throw new NotImplementedException();
        }

        public List<CaseDataModel> GetCaseInBasket(int idUser)
        {
            throw new NotImplementedException();
        }
    }
}
