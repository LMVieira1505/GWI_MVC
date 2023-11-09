using System.ComponentModel.DataAnnotations;

namespace GWI.Models.Subcategoria.Model
{
    public class Subcategorias
    {
        private int Id_subcategoria { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Mínimo de 2 e máximo de 20 caracteres.")]
        private string Nome { get; set; }

        public Subcategorias() 
        {
            Id_subcategoria = 0;
            Nome = string.Empty;
        }
    }
}
