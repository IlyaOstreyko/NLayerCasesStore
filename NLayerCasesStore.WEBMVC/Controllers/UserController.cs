using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerCasesStore.BLL.Interfaces;

namespace NLayerCasesStore.WEBMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
    }
}
