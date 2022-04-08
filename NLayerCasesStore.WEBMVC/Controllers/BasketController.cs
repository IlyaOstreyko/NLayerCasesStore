using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerCasesStore.WEBMVC.ModelsView;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Threading;
using System;
using NLayerCasesStore.BLL.Interfaces;
using AutoMapper;

namespace NLayerCasesStore.WEBMVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly ICaseService _caseService;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, ICaseService caseService, IMapper mapper)
        {
            _basketService = basketService;
            _caseService = caseService;
            _mapper = mapper;
        }
        public IActionResult AddInBasket(int? id)
        {
            if (id != null)
            {
                var caseDto = _caseService.GetCase((int)id);

                if (caseDto != null)
                {
                    var userEmail = User.FindFirst(ClaimTypes.Email).Value;
                    _basketService.AddCaseInBasket(userEmail, (int)id);
                    return RedirectToAction("AllCases", "Case");
                }
            }

            return RedirectToAction("AllCases", "Case");
        }
    }    
}
