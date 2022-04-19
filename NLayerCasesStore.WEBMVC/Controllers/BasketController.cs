using Microsoft.AspNetCore.Mvc;
using NLayerCasesStore.WEBMVC.ModelsView;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using NLayerCasesStore.BLL.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace NLayerCasesStore.WEBMVC.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IUnitOfWorkService _iUnitOfWorkService;
        private readonly IMapper _mapper;

        public BasketController(IUnitOfWorkService iUnitOfWorkService, IMapper mapper)
        {
            _iUnitOfWorkService = iUnitOfWorkService;
            _mapper = mapper;
        }
        
        public IActionResult AddInBasket(int? id)
        {
            if (id.HasValue)
            {
                var caseDto = _iUnitOfWorkService.Cases.GetCase(id.Value);

                if (caseDto != null)
                {
                    //caseDto.CasesNumber = 10;
                    //_iUnitOfWorkService.Cases.UpdateCase(caseDto);
                    var userEmail = User.FindFirst(ClaimTypes.Email).Value;
                    _iUnitOfWorkService.Baskets.AddCaseInBasket(userEmail, caseDto);
                    return RedirectToAction("AllCases", "Case");
                }
            }

            return RedirectToAction("AllCases", "Case");
        }

        public IActionResult AllCasesInBasket()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email).Value;
            var casesDto = _iUnitOfWorkService.Cases.GetCasesInBasketFromEmail(userEmail);
            var casesDM = _mapper.Map<IEnumerable<CaseViewModel>>(casesDto);

            return View(casesDM.ToList());
        }

        public IActionResult DeleteCaseFromBasket(int? id)
        {
            if (id.HasValue)
            {
                var caseDto = _iUnitOfWorkService.Cases.GetCase(id.Value);

                if (caseDto != null)
                {
                    var userEmail = User.FindFirst(ClaimTypes.Email).Value;
                    _iUnitOfWorkService.Baskets.RemoveCaseFromBasket(userEmail, caseDto.CaseId);
                    return RedirectToAction("AllCasesInBasket", "Basket");
                }
            }

            return RedirectToAction("AllCasesInBasket", "Basket");
        }

        public IActionResult ClearBasket()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email).Value;
            _iUnitOfWorkService.Baskets.ClearBasket(userEmail);
            return RedirectToAction("AllCasesInBasket", "Basket");
        }
    }    
}
