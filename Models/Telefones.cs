using System.ComponentModel.DataAnnotations;

namespace GWI.Models
{
    public class Telefones
    {
        public int tl_id { get; set; }

        [Required(ErrorMessage = "Campo DDD obrigatório", AllowEmptyStrings = false)]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "Mínimo de 2 e máximo de 4 caracteres.")]
        public string tl_DDD { get; set; }

        [Required(ErrorMessage = "Campo Número obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 9, ErrorMessage = "Mínimo de 9 e máximo de 10 caracteres.")]
        public string tl_número { get; set; }

        public Telefones()
        {
            tl_id = 0;
            tl_DDD = string.Empty;
            tl_número = string.Empty;
        }

    }
}
