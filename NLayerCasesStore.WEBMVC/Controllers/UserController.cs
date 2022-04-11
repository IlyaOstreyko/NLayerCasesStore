using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerCasesStore.BLL.Interfaces;

namespace NLayerCasesStore.WEBMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWorkService _iUnitOfWorkService;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWorkService iUnitOfWorkService, IMapper mapper)
        {
            _iUnitOfWorkService = iUnitOfWorkService;
            _mapper = mapper;
        }
    }
}
