

namespace NLayerCasesStore.DAL.DataModels
{
    public class OrderCaseDataModel
    {
        public int OrderId { get; set; }
        public OrderDataModel Order { get; set; }

        public int CaseId { get; set; }
        public CaseDataModel Case { get; set; }

        public int CountCasesInOrder { get; set; }
    }
}
