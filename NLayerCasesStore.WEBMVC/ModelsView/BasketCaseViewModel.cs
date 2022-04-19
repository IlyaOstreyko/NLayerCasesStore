using NLayerCasesStore.WEBMVC.ModelsView;

namespace NLayerCasesStore.WEBMVC.ModelsView
{
    public class BasketCaseViewModel
    {
        public int BasketId { get; set; }
        public BasketViewModel Basket { get; set; }

        public int CaseId { get; set; }
        public CaseViewModel Case { get; set; }

        public int NumberPairBasketCase { get; set; }
    }
}
