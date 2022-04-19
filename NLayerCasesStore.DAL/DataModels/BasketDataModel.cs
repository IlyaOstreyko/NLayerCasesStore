
using System.Collections.Generic;

namespace NLayerCasesStore.DAL.DataModels
{
    public class BasketDataModel
    {
        public int BasketId { get; set; }
        public int? UserId { get; set; }
        public List<BasketCaseDataModel> BasketsCases { get; set; } = new List<BasketCaseDataModel>();
    }
}
