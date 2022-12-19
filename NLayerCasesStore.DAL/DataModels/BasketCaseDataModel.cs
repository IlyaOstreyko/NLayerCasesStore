

namespace NLayerCasesStore.DAL.DataModels
{
    public class BasketCaseDataModel
    {
        public int BasketId { get; set; }
        public BasketDataModel Basket { get; set; }

        public int CaseId { get; set; }
        public CaseDataModel Case { get; set; }

        public int CountCasesInBasket { get; set; }
    }
}
