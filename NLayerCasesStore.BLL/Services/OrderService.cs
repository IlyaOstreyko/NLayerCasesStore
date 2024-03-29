﻿using AutoMapper;
using NLayerCasesStore.BLL.DTO;
using NLayerCasesStore.BLL.Interfaces;
using NLayerCasesStore.DAL.DataModels;
using NLayerCasesStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public OrderDTO GetOrder(int? id)
        {
            var orderDM = _unitOfWork.Orders.Get(id.Value);
            var orderDto = _mapper.Map<OrderDTO>(orderDM);

            return orderDto;

        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetUserOrders(string userEmail, string status)
        {
            var ordersDM = _unitOfWork.Orders.GetUserOrders(userEmail, status);
            var ordersDto = _mapper.Map<IEnumerable<OrderDTO>>(ordersDM);

            return ordersDto;
        }

        public bool MakeOrder(string userEmail, string address)
        {
            var casesDto = _unitOfWork.Cases.GetCasesInBasketInStock(userEmail);
            if (casesDto.Any())
            {
                var casesDM = _mapper.Map<IEnumerable<CaseDataModel>>(casesDto);
                _unitOfWork.Orders.Create(userEmail, address, casesDM);
                SendMessage(userEmail, address);

                _unitOfWork.Save();

                return true;
            }

            return false;

        }
        public void CloseOrder(int? id)
        {
            _unitOfWork.Orders.CloseOrder(id.Value);
            _unitOfWork.Save();

        }
        public void SendMessage(string userEmail, string address)
        {
            MailAddress store = new MailAddress("ilyaostreyko@gmail.com", "CasesStore");
            MailAddress user = new MailAddress(userEmail);
            MailMessage messageForUser = new MailMessage(store, user);
            messageForUser.Subject = "you are created order";
            messageForUser.Body = "<h2>Adress: </h2>" + address;
            messageForUser.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("ilyaostreyko@gmail.com", "zuohczqizfkoojai");
            smtp.EnableSsl = true;
            smtp.Send(messageForUser);
            MailMessage messageForAdmin = new MailMessage(user, store);
            messageForAdmin.Subject = "create order";
            messageForAdmin.Body = "<h2>user: </h2>" + userEmail + "<h2>Adress: </h2>" + address;
            messageForAdmin.IsBodyHtml = true;
            smtp.Send(messageForAdmin);
        }

    }
}
