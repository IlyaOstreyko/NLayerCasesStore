using AutoMapper;
using NLayerCasesStore.BLL.DTO;
using NLayerCasesStore.WEBMVC.ModelsView;

namespace NLayerCasesStore.WEBMVC.Mappers
{
    public class AppMappingProfileWEB : Profile
    {
        public AppMappingProfileWEB()
        {
            CreateMap<CaseDTO, CaseViewModel>().ReverseMap();
            CreateMap<BasketDTO, BasketViewModel>().ReverseMap();
            CreateMap<OrderDTO, OrderViewModel>().ReverseMap();
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
            CreateMap<UserDTO, RegisterModel>().ReverseMap();
        }
    }
}
