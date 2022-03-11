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
        public string Status { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public virtual List<Case> Cases { get; set; }
        public Order()
        {
            Cases = new List<Case>();
        }
    }
}
