using AutoMapper;
using NLayerCasesStore.BLL.DTO;
using NLayerCasesStore.WEB.ModelsView;

namespace NLayerCasesStore.WEB.Mappers
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
