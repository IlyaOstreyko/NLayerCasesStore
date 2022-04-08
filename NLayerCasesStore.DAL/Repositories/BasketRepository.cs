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
        }
        public void AddCaseInBasket(int idUser, CaseDataModel caseDM)
        {
            var basket = _casesStoreContext.Baskets.FirstOrDefault(b => b.UserId == idUser);

            if (basket is null)
            {
                Create(idUser);
            }

            basket = _casesStoreContext.Baskets.FirstOrDefault(b => b.UserId == idUser);
            var caseItem = _mapper.Map<Case>(caseDM);
            basket.Cases.Add(caseItem);
        }

        public void ClearBasket()
        {
            throw new NotImplementedException();
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
