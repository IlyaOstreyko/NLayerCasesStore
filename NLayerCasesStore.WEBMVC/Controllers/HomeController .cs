using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerCasesStore.WEBMVC.ModelsView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerCasesStore.BLL.Interfaces;
using NLayerCasesStore.BLL.DTO;
using Microsoft.AspNetCore.Authorization;

namespace NLayerCasesStore.WEBMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkService _iUnitOfWorkService;
        private readonly IMapper _mapper;

        public HomeController(IUnitOfWorkService iUnitOfWorkService, IMapper mapper)
        {
            _iUnitOfWorkService = iUnitOfWorkService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
