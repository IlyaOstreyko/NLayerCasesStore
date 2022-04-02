using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerCasesStore.WEB.ModelsView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerCasesStore.BLL.Interfaces;
using NLayerCasesStore.BLL.DTO;
using Microsoft.AspNetCore.Authorization;

namespace NLayerCasesStore.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ICaseService _caseService;
        public readonly IMapper _mapper;

        public HomeController(ICaseService caseService, IMapper mapper)
        {
            _caseService = caseService;
            _mapper = mapper;
        }
        [Authorize]
        public ActionResult AllCases()
        {
            var caseDtos = _caseService.GetCases();
            var casesDM = _mapper.Map<IEnumerable<CaseViewModel>>(caseDtos);
            return View(casesDM.ToList());
        }
        //public ActionResult MakeOrder(int? id)
        //{
        //    try
        //    {
        //        CaseDTO itemCase = caseService.GetPhone(id);
        //        var order = new CaseViewModel { CaseId = itemCase.Id };

        //        return View(order);
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return Content(ex.Message);
        //    }
        //}
        //[HttpPost]
        //public ActionResult MakeOrder(CaseViewModel order)
        //{
        //    try
        //    {
        //        var orderDto = new OrderDTO { PhoneId = order.PhoneId, Address = order.Address, PhoneNumber = order.PhoneNumber };
        //        orderService.MakeOrder(orderDto);
        //        return Content("<h2>Ваш заказ успешно оформлен</h2>");
        //    }
        //    catch (ValidationException ex)
        //    {
        //        ModelState.AddModelError(ex.Property, ex.Message);
        //    }
        //    return View(order);
        //}
    }
}
