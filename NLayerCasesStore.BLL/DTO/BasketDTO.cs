
using NLayerCasesStore.BLL.DTO;
using System.Collections.Generic;

namespace NLayerCasesStore.BLL.DTO
{
    public class BasketDTO
    {
        public int BasketId { get; set; }
        public int? UserId { get; set; }
        public List<BasketCaseDTO> BasketsCases { get; set; } = new List<BasketCaseDTO>();
    }
}
