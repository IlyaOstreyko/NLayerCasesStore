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
        public void AddNumberCaseInBasket(int idUser, CaseDataModel caseDM)
        {
            var basket = _casesStoreContext.Baskets.Include(a => a.BasketsCases.Where(a => a.CaseId == caseDM.CaseId))
                .FirstOrDefault(b => b.UserId == idUser);
            basket.BasketsCases[0].CountCasesInBasket++;
        }
        public bool CheckCaseInBasket(int idUser, CaseDataModel caseDM)
        {
            var basket = _casesStoreContext.Baskets.Include(a => a.BasketsCases.Where(a => a.CaseId == caseDM.CaseId))
                .FirstOrDefault(b => b.UserId == idUser);

            if (basket is not null && basket.BasketsCases.Any() && basket.BasketsCases[0].CountCasesInBasket > 0 )
            {
                return true;
            }
            return false;
        }

        public void AddCaseInBasket(int idUser, CaseDataModel caseDM)
        {
            //int count = _casesStoreContext.Cases.Local.Count;
            _casesStoreContext.ChangeTracker.Clear();
            //count = _casesStoreContext.Cases.Local.Count;

            //var itemCase = _mapper.Map<Case>(caseDM);
            var itemCase = _casesStoreContext.Cases.Find(caseDM.CaseId);
            var basket = _casesStoreContext.Baskets.FirstOrDefault(b => b.UserId == idUser);

            if (basket is null)
            {
                basket = new Basket { UserId = idUser };
                _casesStoreContext.Baskets.Add(basket);
            }
            basket.Cases.Add(itemCase);
        }
        public void RemoveCaseFromBasket(int idUser, int caseId)
        {
            var basket = _casesStoreContext.Baskets
                .Include(a => a.Cases)
                .FirstOrDefault(b => b.UserId == idUser);

            var itemCase = basket.Cases.FirstOrDefault(x => x.CaseId == caseId);
            basket.Cases.Remove(itemCase);
        }
        
        public void ClearBasket(int idUser)
        {
            var basket = _casesStoreContext.Baskets
                .Include(a => a.Cases)
                .FirstOrDefault(b => b.UserId == idUser);

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
