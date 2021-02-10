using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SnackHouse.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Digite o nome de usuário!")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário!")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
