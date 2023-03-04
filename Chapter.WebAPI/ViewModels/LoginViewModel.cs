using System.ComponentModel.DataAnnotations;

namespace Chapter.WebAPI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O e-mail é Obrigatório !")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é Obrigatória !")]
        public string? Senha { get; set; }
    }
}
