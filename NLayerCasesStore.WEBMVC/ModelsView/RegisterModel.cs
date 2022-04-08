using System.ComponentModel.DataAnnotations;

namespace NLayerCasesStore.WEBMVC.ModelsView
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string UserMail { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
