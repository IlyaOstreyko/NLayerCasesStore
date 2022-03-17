using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLayerCasesStore.DAL.Entities
{
    public class User
    {
        [Key, Required]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }   
        public string UserRole { get; set; }  
        public int? BasketId { get; set; }
        [ForeignKey("BasketId")]
        public Basket Basket { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
