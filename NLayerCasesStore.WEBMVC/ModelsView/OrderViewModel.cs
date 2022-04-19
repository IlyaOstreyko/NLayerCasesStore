using System;
using System.Collections.Generic;

namespace NLayerCasesStore.WEBMVC.ModelsView
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string Address { get; set; }
        public DateTime DataOrder { get; set; }
        public DateTime? DataClose { get; set; }
        public string Status { get; set; }
        public int? UserId { get; set; }
        public List<CaseViewModel> Cases { get; set; }
    }
}
