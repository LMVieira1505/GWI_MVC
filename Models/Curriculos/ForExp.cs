using System.ComponentModel.DataAnnotations;

namespace GWI.Models.Curriculos
{
    public class ForExp
    {

        public int fe_id { get; set; }

        [Required(ErrorMessage = "Campo texto obrigatório", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 500 caracteres.")]
        public string fe_instituicao { get; set; }

        [Required(ErrorMessage = "Campo ano de início obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Mínimo de 4 e máximo de 10 caracteres.")]
        public string fe_ano_ini { get; set; }

        [Required(ErrorMessage = "Campo ano de término obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Mínimo de 4 e máximo de 10 caracteres.")]
        public string fe_ano_ter { get; set; }

        [Required(ErrorMessage = "Campo descrição obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 200 caracteres.")]
        public string fe_descricao { get; set; }

        [Required(ErrorMessage = "Campo área de atuação obrigatório")]
        public int fe_ar_id { get; set; }



        public ForExp()
        {
            fe_id = 0;
            fe_instituicao = string.Empty;
            fe_ano_ini = string.Empty;
            fe_ano_ter = string.Empty;
            fe_descricao = string.Empty;
            fe_ar_id = 0;
        }
    }
}