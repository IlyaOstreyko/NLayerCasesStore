using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLayerCasesStore.DAL.Entities
{
    public class Order
    {
        [Required, Key]
        public int OrderId { get; set; }
        public string Address { get; set; }
        public DateTime DataOrder { get; set; }
        public DateTime? DataClose { get; set; }
        public string Status { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public List<Case> Cases { get; set; } = new List<Case>();
        public List<OrderCase> OrdersCases { get; set; } = new List<OrderCase>();
    }
}
