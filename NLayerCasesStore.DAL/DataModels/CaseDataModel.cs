
using System.Collections.Generic;

namespace NLayerCasesStore.DAL.DataModels
{
    public class CaseDataModel
    {
        public int CaseId { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int CasesNumber { get; set; }
        public List<BasketCaseDataModel> BasketsCases { get; set; } = new List<BasketCaseDataModel>();
    }
}
