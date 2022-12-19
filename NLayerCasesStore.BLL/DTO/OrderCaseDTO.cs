using NLayerCasesStore.BLL.DTO;

namespace NLayerCasesStore.BLL.DTO
{
    public class OrderCaseDTO
    {
        public int OrderId { get; set; }
        public OrderDTO Order { get; set; }

        public int CaseId { get; set; }
        public CaseDTO Case { get; set; }

        public int CountCasesInOrder { get; set; }
    }
}
