using AutoMapper;
using NLayerCasesStore.BLL.Services;
using NLayerCasesStore.WEB.ModelsView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NLayerCasesStore.WEB.Controllers
{
    public class HomeController : Controller
    {
        ICaseService caseService;
        public HomeController(ICaseService serv)
        {
            caseService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<CaseDTO> caseDtos = caseService.GetCases();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CaseDTO, CaseViewModel>()).CreateMapper();
            var cases = mapper.Map<IEnumerable<CaseDTO>, List<CaseViewModel>>(caseDtos);
            return View(cases);
        }

        public ActionResult MakeOrder(int? id)
        {
            try
            {
                CaseDTO itemCase = caseService.GetPhone(id);
                var order = new CaseViewModel { CaseId = itemCase.Id };

                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(CaseViewModel order)
        {
            try
            {
                var orderDto = new OrderDTO { PhoneId = order.PhoneId, Address = order.Address, PhoneNumber = order.PhoneNumber };
                orderService.MakeOrder(orderDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }
    }
}
