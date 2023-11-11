using System.ComponentModel.DataAnnotations;

namespace GWI.Models
{
    public class Subcategorias
    {
        public int sct_id { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Mínimo de 2 e máximo de 20 caracteres.")]
        public string sct_nome { get; set; }

        public Subcategorias()
        {
            sct_id = 0;
            sct_nome = string.Empty;
        }
    }
}
