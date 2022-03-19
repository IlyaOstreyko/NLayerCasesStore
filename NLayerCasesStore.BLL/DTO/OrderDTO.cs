using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.BLL.DTO
{
    internal class OrderDTO
    {
        public int OrderId { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public int? UserId { get; set; }
    }
}
