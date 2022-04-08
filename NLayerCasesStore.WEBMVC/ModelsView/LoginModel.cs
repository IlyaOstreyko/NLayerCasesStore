using System.ComponentModel.DataAnnotations;

namespace NLayerCasesStore.WEBMVC.ModelsView
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string UserMail { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}
