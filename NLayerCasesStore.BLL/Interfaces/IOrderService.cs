using NLayerCasesStore.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.BLL.Interfaces
{
    public interface IOrderService
    {
        bool MakeOrder(string userEmail, string address);
        OrderDTO GetOrder(int? id);
        void CloseOrder(int? id);
        IEnumerable<OrderDTO> GetOrders();
        IEnumerable<OrderDTO> GetUserOrders(string userEmail, string status);
        
    }
}
