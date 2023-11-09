using System.ComponentModel.DataAnnotations;

namespace GWI.Models.FormAcad.Model
{
    public class FormsAcads
    {
        private int Id { get; set; }

        [Required(ErrorMessage = "Campo instituição obrigatório", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Mínimo de 5 e máximo de 20 caracteres.")]
        private string Instituicao { get; set; }

        [Required(ErrorMessage = "Campo área de formação obrigatório", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Mínimo de 5 e máximo de 20 caracteres.")]
        private string AreaFor { get; set; }

        [Required(ErrorMessage = "Campo ano de início obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Mínimo de 4 e máximo de 10 caracteres.")]
        private string AnoInicio { get; set; }

        [Required(ErrorMessage = "Campo ano de término obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Mínimo de 4 e máximo de 10 caracteres.")]
        private string AnoTermino { get; set; }

        [Required(ErrorMessage = "Campo descrição obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 200 caracteres.")]
        private string Descricao { get; set; }

        public FormsAcads()
        {
            Id = 0;
            Instituicao = string.Empty;
            AreaFor = string.Empty;
            AnoInicio = string.Empty;
            AnoTermino = string.Empty;
            Descricao = string.Empty;
        }
    }
}
