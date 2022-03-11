using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLayerCasesStore.DAL.Entities
{
    public class User
    {
        [Key, Required]
        public int UserId { get; set; }
        public string Name_user { get; set; }
        public string Mail_user { get; set; }
        public string Password_user { get; set; }        
        public int? BasketId { get; set; }
        [ForeignKey("BasketId")]
        public Basket Basket { get; set; }
        public virtual List<Order> Orders { get; set; }
        public User()
        {
            Orders = new List<Order>();
        }
    }
}
