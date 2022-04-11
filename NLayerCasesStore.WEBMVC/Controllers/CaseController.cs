using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayerCasesStore.BLL.DTO;
using NLayerCasesStore.BLL.Interfaces;
using NLayerCasesStore.WEBMVC.ModelsView;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace NLayerCasesStore.WEBMVC.Controllers
{
    public class CaseController : Controller
    {
        private readonly IUnitOfWorkService _iUnitOfWorkService;
        private readonly IMapper _mapper;

        public CaseController(IUnitOfWorkService iUnitOfWorkService, IMapper mapper)
        {
            _iUnitOfWorkService = iUnitOfWorkService;
            _mapper = mapper;
        }

        //[HttpPost]
        public IActionResult AllCases()
        {
            var casesDto = _iUnitOfWorkService.Cases.GetCases();
            var casesDM = _mapper.Map<IEnumerable<CaseViewModel>>(casesDto);

            return View(casesDM.ToList());
        }

        [Authorize(Policy = "OnlyForAdmin")]
        public IActionResult AddCase()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddCase(CaseViewModel caseVM)
        {
            _iUnitOfWorkService.Cases.CreateCase(_mapper.Map<CaseDTO>(caseVM));

            return RedirectToAction("AllCases");
        }

        [Authorize(Policy = "OnlyForAdmin")]
        public IActionResult EditCase(int? id)
        {
            if (id.HasValue)
            {
                var caseDto = _iUnitOfWorkService.Cases.GetCase(id.Value);

                if (caseDto != null)
                {
                    var caseVM = _mapper.Map<CaseViewModel>(caseDto);

                    return View(caseVM);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditCase(CaseViewModel caseVM)
        {
            //_iUnitOfWorkService.Baskets.AddCaseInBasket("ilyaostreyko@gmail.com", _mapper.Map<CaseDTO>(caseVM));
            _iUnitOfWorkService.Cases.UpdateCase(_mapper.Map<CaseDTO>(caseVM));
            return RedirectToAction("AllCases");
        }

        [HttpGet]
        [ActionName("DeleteCase")]
        [Authorize(Policy = "OnlyForAdmin")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id.HasValue)
            {
                var caseDto = _iUnitOfWorkService.Cases.GetCase(id.Value);

                if (caseDto != null)
                {
                    var caseVM = _mapper.Map<CaseViewModel>(caseDto);

                    return View(caseVM);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteCase(int? id)
        {
            if (id.HasValue)
            {
                var caseDto = _iUnitOfWorkService.Cases.GetCase(id.Value);

                if (caseDto != null)
                {
                    _iUnitOfWorkService.Cases.DeleteCase(id.Value);

                    return RedirectToAction("AllCases");
                }
            }

            return NotFound();
        }
    }
}
