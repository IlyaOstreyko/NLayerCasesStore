using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayerCasesStore.BLL.Interfaces;
using NLayerCasesStore.WEBMVC.ModelsView;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace NLayerCasesStore.WEBMVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWorkService _iUnitOfWorkService;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWorkService iUnitOfWorkService, IMapper mapper)
        {
            _iUnitOfWorkService = iUnitOfWorkService;
            _mapper = mapper;
        }

        public IActionResult AddOrder()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email).Value;
            var casesDto = _iUnitOfWorkService.Cases.GetCasesInBasketInStock(userEmail);
            var casesDM = _mapper.Map<IEnumerable<CaseViewModel>>(casesDto);

            return View(casesDM.ToList());
        }


        [HttpPost]
        public IActionResult AddOrder(string address)
        {
            if (address is null)
            {
                return RedirectToAction("UserOrders", "Basket");
            }

            var userEmail = User.FindFirst(ClaimTypes.Email).Value;
            if (_iUnitOfWorkService.Orders.MakeOrder(userEmail, address))
            {
                return RedirectToAction("UserOrders", "Order");
            }
            ModelState.AddModelError("", "no cases in basket or stock");
            return View();
        }

        public IActionResult UserOrders()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email).Value;
            var ordersDto = _iUnitOfWorkService.Orders.GetUserOrders(userEmail, "open");
            var ordersDM = _mapper.Map<IEnumerable<OrderViewModel>>(ordersDto);
            return View(ordersDM.ToList());
        }

        public IActionResult UserCloseOrders()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email).Value;
            var ordersDto = _iUnitOfWorkService.Orders.GetUserOrders(userEmail, "close");
            var ordersDM = _mapper.Map<IEnumerable<OrderViewModel>>(ordersDto);

            return View(ordersDM.ToList());
        }

        [Authorize(Policy = "OnlyForAdmin")]
        public IActionResult AllOrders()
        {
            var ordersDto = _iUnitOfWorkService.Orders.GetUserOrders("all", "open");
            var ordersDM = _mapper.Map<IEnumerable<OrderViewModel>>(ordersDto);

            return View(ordersDM.ToList());
        }

        [Authorize(Policy = "OnlyForAdmin")]
        public IActionResult AllCloseOrders()
        {
            var ordersDto = _iUnitOfWorkService.Orders.GetUserOrders("all", "close");
            var ordersDM = _mapper.Map<IEnumerable<OrderViewModel>>(ordersDto);

            return View(ordersDM.ToList());
        }

        [Authorize(Policy = "OnlyForAdmin")]
        public IActionResult CloseOrder(int? id)
        {
            if (id.HasValue)
            {
                var caseDto = _iUnitOfWorkService.Orders.GetOrder(id.Value);

                if (caseDto != null)
                {
                    _iUnitOfWorkService.Orders.CloseOrder(id.Value);

                    return RedirectToAction("AllOrders", "Order");
                }
            }

            return RedirectToAction("AllOrders", "Order");
        }
    }
}
