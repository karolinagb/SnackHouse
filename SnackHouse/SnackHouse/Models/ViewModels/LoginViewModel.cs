using System.ComponentModel.DataAnnotations;

namespace SnackHouse.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Digite o nome de usuário!")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário!")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string URL { get; set; }
    }
}
