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
    public class BasketRepository : IRepository<BasketDataModel>
    {
        private CasesStoreContext _casesStoreContext;
        private readonly IMapper _mapper;

        public BasketRepository(CasesStoreContext casesStoreContext, IMapper mapper)
        {
            _casesStoreContext = casesStoreContext;
            _mapper = mapper;
        }

        public IEnumerable<BasketDataModel> GetAll()
        {
            var baskets = _casesStoreContext.Baskets.Include(o => o.Cases);
            var basketsDM = _mapper.Map<IEnumerable<BasketDataModel>>(baskets);
            return basketsDM;
        }

        public BasketDataModel Get(int id)
        {
            var basket = _casesStoreContext.Baskets.Find(id);
            var basketDM = _mapper.Map<BasketDataModel>(basket);

            return basketDM;
        }

        public void Create(BasketDataModel itemBasketDM)
        {
            var itemBasket = _mapper.Map<Basket>(itemBasketDM);
            _casesStoreContext.Baskets.Add(itemBasket);
        }

        public void Update(BasketDataModel itemBasketDM)
        {
            var itemBasket = _mapper.Map<Basket>(itemBasketDM);
            _casesStoreContext.Entry(itemBasket).State = EntityState.Modified;
        }
        //public IEnumerable<BasketDataModel> Find(Func<BasketDataModel, bool> predicate)
        //{
        //    return _casesStoreContext.Baskets.Where(predicate).ToList();
        //}
        public void Delete(int id)
        {
            Basket itembasket = _casesStoreContext.Baskets.Find(id);
            if (itembasket != null)
                _casesStoreContext.Baskets.Remove(itembasket);
        }
    }
}
