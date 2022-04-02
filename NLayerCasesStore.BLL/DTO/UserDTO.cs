

namespace NLayerCasesStore.BLL.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
        public int? BasketId { get; set; }
    }
}
