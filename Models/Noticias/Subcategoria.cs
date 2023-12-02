using System.ComponentModel.DataAnnotations;

namespace GWI.Models.Noticias
{
    public class Subcategoria
    {
        public int sctnt_id { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres.")]
        public int sctnt_nt_id { get; set; }

        public int sbtnt_sct_id { get; set; }

        public Subcategoria()
        {
            sctnt_id = 0;
            sctnt_nt_id = 0;
            sbtnt_sct_id = 0;
        }
    }
}
