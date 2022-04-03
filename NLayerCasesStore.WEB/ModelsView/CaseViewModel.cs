using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.WEB.ModelsView
{
    internal class CaseViewModel
    {
        public int CaseId { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int CasesNumber { get; set; }
    }
}
