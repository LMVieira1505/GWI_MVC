using System.ComponentModel.DataAnnotations;

namespace GWI.Models
{
    public class Pessoas
    {
        private string Senha { get; set; }

        private bool Ativo;
        private int Id_pess { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo de 10 e máximo de 50 caracteres.")]
        private string Nome { get; set; }

        [Required(ErrorMessage = "Campo Sobrenome obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo de 10 e máximo de 50 caracteres.")]
        private string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo de 10 e máximo de 500 caracteres.")]
        private List<string> Telefone { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo de 10 e máximo de 500 caracteres.")]
        private List<string> Email { get; set; }

        public class Usuario : Pessoas
        {

        }

        public class Administrador : Pessoas
        {

        }

        public class Autor : Pessoas
        {
            private string Cidade { get; set; }
        }
        public Pessoas()
        {
            Senha = string.Empty;
            Ativo = false;
            Id_pess = 0;
            Nome = string.Empty;
            Sobrenome = string.Empty;
            Telefone = new List<string>();
            Email = new List<string>();
        }

    }
}

