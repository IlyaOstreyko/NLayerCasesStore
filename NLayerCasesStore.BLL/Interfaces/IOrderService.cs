using NLayerCasesStore.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.BLL.Interfaces
{
    internal interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        CaseDTO GetCase(int? id);
        IEnumerable<CaseDTO> GetCase();
        void Dispose();
    }
}
