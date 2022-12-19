using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.DAL.Entities
{
    public class OrderCase
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int CaseId { get; set; }
        public Case Case { get; set; }

        public int CountCaseInOrder { get; set; }
    }
}
