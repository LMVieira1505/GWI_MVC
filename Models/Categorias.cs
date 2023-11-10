using System.ComponentModel.DataAnnotations;

namespace GWI.Models
{
    public class Categorias
    {
        private int Id_categoria { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres.")]
        private string Nome { get; set; }

        public Categorias()
        {
            Id_categoria = 0;
            Nome = string.Empty;
        }

    }
}
