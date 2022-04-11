using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLayerCasesStore.DAL.Entities
{
    public class Case
    {
        [Required, Key]
        public int CaseId { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int CasesNumber { get; set; }
        public virtual List<Order> Orders { get; set; } = new List<Order>();
        public virtual List<Basket> Baskets { get; set; } = new List<Basket>();
    }
}
