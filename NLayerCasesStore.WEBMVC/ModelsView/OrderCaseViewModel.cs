using NLayerCasesStore.WEBMVC.ModelsView;

namespace NLayerCasesStore.WEBMVC.ModelsView
{
    public class OrderCaseViewModel
    {
        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; }

        public int CaseId { get; set; }
        public CaseViewModel Case { get; set; }

        public int CountCasesInOrder { get; set; }
    }
}
