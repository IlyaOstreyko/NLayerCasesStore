

using NLayerCasesStore.BLL.DTO;
using System.Collections.Generic;

namespace NLayerCasesStore.BLL.DTO
{
    public class CaseDTO
    {
        public int CaseId { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int CasesNumber { get; set; }
        public List<BasketCaseDTO> BasketsCases { get; set; } = new List<BasketCaseDTO>();
        public List<OrderCaseDTO> OrdersCases { get; set; } = new List<OrderCaseDTO>();
    }
}
