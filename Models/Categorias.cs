using System.ComponentModel.DataAnnotations;

namespace GWI.Models
{
    public class Categorias
    {
        public int cat_id { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres.")]
        public string cat_nome { get; set; }

        public Categorias()
        {
            cat_id = 0;
            cat_nome = string.Empty;
        }

    }
}
