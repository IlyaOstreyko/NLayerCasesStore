using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerCasesStore.BLL.DTO;
using NLayerCasesStore.BLL.Interfaces;
using NLayerCasesStore.WEBMVC.ModelsView;
using System.Collections.Generic;
using System.Linq;

namespace NLayerCasesStore.WEBMVC.Controllers
{
    public class CaseController : Controller
    {
        public ICaseService _caseService;
        public readonly IMapper _mapper;

        public CaseController(ICaseService caseService, IMapper mapper)
        {
            _caseService = caseService;
            _mapper = mapper;
        }
        //[HttpPost]
        public IActionResult AllCases()
        {
            var caseDtos = _caseService.GetCases();
            var casesDM = _mapper.Map<IEnumerable<CaseViewModel>>(caseDtos);
            return View(casesDM.ToList());
        }
        public IActionResult AddCase()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCase(CaseViewModel caseVM)
        {
            _caseService.CreateCase(_mapper.Map<CaseDTO>(caseVM));
            return RedirectToAction("AllCases");
        }
        public IActionResult EditCase(int? id)
        {
            if (id != null)
            {
                var caseDto = _caseService.GetCase((int)id);
                if (caseDto != null)
                    return View(_mapper.Map<CaseViewModel>(caseDto));
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult EditCase(CaseViewModel caseVM)
        {
            _caseService.UpdateCase(_mapper.Map<CaseDTO>(caseVM));
            return RedirectToAction("AllCases");
        }
        [HttpGet]
        [ActionName("DeleteCase")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                var caseDto = _caseService.GetCase((int)id);
                if (caseDto != null)
                    return View(_mapper.Map<CaseViewModel>(caseDto));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteCase(int? id)
        {
            if (id != null)
            {
                var caseDto = _caseService.GetCase((int)id);
                if (caseDto != null)
                {
                    _caseService.DeleteCase((int)id);
                    return RedirectToAction("AllCases");
                }
            }
            return NotFound();
        }
    }
}
