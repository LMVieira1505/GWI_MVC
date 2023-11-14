using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWI.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Campo Usuário obrigatório", AllowEmptyStrings = false)]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 30 caracteres.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo Senha obrigatório", AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Mínimo de 6 e máximo de 15 caracteres.")]
        public string Senha { get; set; }

        public Login()
        {
            this.Usuario = "";
            this.Senha = "";
        }    
    }
}
