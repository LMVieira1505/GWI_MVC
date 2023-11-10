using System.ComponentModel.DataAnnotations;

namespace GWI.Models
{
    public class FormsAcads
    {
        public int fcd_id { get; set; }

        [Required(ErrorMessage = "Campo instituição obrigatório", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Mínimo de 5 e máximo de 20 caracteres.")]
        public string fcd_instituicao { get; set; }

        [Required(ErrorMessage = "Campo área de formação obrigatório", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Mínimo de 5 e máximo de 20 caracteres.")]
        public string fcd_area { get; set; }

        [Required(ErrorMessage = "Campo ano de início obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Mínimo de 4 e máximo de 10 caracteres.")]
        public string fcd_ano_ini { get; set; }

        [Required(ErrorMessage = "Campo ano de término obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Mínimo de 4 e máximo de 10 caracteres.")]
        public string fcd_ano_ter { get; set; }

        [Required(ErrorMessage = "Campo descrição obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 200 caracteres.")]
        public string fcd_descricao { get; set; }

        

        public FormsAcads()
        {
            fcd_id = 0;
            fcd_instituicao = string.Empty;
            fcd_area = string.Empty;
            fcd_ano_ini = string.Empty;
            fcd_ano_ter = string.Empty;
            fcd_descricao = string.Empty;
            
        }
    }
}
