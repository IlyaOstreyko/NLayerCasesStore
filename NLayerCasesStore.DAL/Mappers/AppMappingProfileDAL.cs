using AutoMapper;
using NLayerCasesStore.DAL.DataModels;
using NLayerCasesStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.DAL.Mappers
{
    public class AppMappingProfileDAL : Profile
    {
        public AppMappingProfileDAL()
        {
            CreateMap<Case, CaseDataModel>().ReverseMap();
            CreateMap<Basket, BasketDataModel>().ReverseMap();
            CreateMap<Order, OrderDataModel>().ReverseMap();
            CreateMap<User, UserDataModel>().ReverseMap();
            CreateMap<BasketCase, BasketCaseDataModel>().ReverseMap();
            CreateMap<OrderCase, OrderCaseDataModel>().ReverseMap();
        }
    }
}
