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
        public List<Case> Cases { get; set; } = new List<Case>();
        public List<BasketCase> BasketsCases { get; set; } = new List<BasketCase>();
    }
}
