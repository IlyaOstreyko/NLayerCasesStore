using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLayerCasesStore.DAL.Entities
{
    public class Basket
    {
        [Required, Key]
        public int BasketId { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public virtual List<Case> Cases { get; set; }
        public Basket()
        {
            Cases = new List<Case>();
        }
    }
}
