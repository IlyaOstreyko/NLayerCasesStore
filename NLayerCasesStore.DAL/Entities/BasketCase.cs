using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.DAL.Entities
{
    public class BasketCase
    {
        public int BasketId { get; set; }
        public Basket Basket { get; set; }

        public int CaseId { get; set; }
        public Case Case { get; set; }

        public int NumberPairBasketCase { get; set; }
    }
}
