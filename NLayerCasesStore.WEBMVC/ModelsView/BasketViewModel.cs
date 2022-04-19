using System.Collections.Generic;

namespace NLayerCasesStore.WEBMVC.ModelsView
{
    public class BasketViewModel
    {
        public int BasketId { get; set; }
        public int? UserId { get; set; }
        public List<BasketCaseViewModel> BasketsCases { get; set; } = new List<BasketCaseViewModel>();
    }
}
