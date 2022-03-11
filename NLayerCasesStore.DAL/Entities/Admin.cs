using System.ComponentModel.DataAnnotations;

namespace NLayerCasesStore.DAL.Entities
{
    public class Admin
    {
        [Key, Required]
        public int Id { get; set; }
        public string Name_admin { get; set; }
        public string Password_admin { get; set; }
        public string Mail_admin { get; set; }
    }
}
