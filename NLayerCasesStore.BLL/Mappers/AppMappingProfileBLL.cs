using AutoMapper;
using NLayerCasesStore.BLL.DTO;
using NLayerCasesStore.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.BLL.Mappers
{
    public class AppMappingProfileBLL : Profile
    {
        public AppMappingProfileBLL()
        {
            CreateMap<CaseDataModel, CaseDTO>().ReverseMap();
            CreateMap<BasketDataModel, BasketDTO>().ReverseMap();
            CreateMap<OrderDataModel, OrderDTO>().ReverseMap();
            CreateMap<UserDataModel, UserDTO>().ReverseMap();
            CreateMap<BasketCaseDataModel, BasketCaseDTO>().ReverseMap();
            CreateMap<OrderCaseDataModel, OrderCaseDTO>().ReverseMap();
        }
    }
}
