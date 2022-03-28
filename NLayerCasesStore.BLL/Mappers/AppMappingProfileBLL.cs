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
            CreateMap<CaseDataModel, CaseDTO>();
        }
    }
}
