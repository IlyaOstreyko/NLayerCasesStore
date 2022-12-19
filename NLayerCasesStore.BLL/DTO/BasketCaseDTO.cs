using NLayerCasesStore.BLL.DTO;

namespace NLayerCasesStore.BLL.DTO
{
    public class BasketCaseDTO
    {
        public int BasketId { get; set; }
        public BasketDTO Basket { get; set; }

        public int CaseId { get; set; }
        public CaseDTO Case { get; set; }

        public int CountCasesInBasket { get; set; }
    }
}
