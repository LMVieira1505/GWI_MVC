using System.ComponentModel.DataAnnotations;

namespace GWI.Models
{
    public class ExpsProfs
    {

        private int Id { get; set; }

        [Required(ErrorMessage = "Campo texto obrigatório", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 500 caracteres.")]
        private string Empresa { get; set; }

        [Required(ErrorMessage = "Campo área de atuação obrigatório", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Mínimo de 5 e máximo de 20 caracteres.")]
        private string AreaAtu { get; set; }

        [Required(ErrorMessage = "Campo ano de início obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Mínimo de 4 e máximo de 10 caracteres.")]
        private string AnoInicio { get; set; }

        [Required(ErrorMessage = "Campo ano de término obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Mínimo de 4 e máximo de 10 caracteres.")]
        private string AnoTermino { get; set; }

        [Required(ErrorMessage = "Campo descrição obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 200 caracteres.")]
        private string Descricao { get; set; }

        public ExpsProfs()
        {

            Id = 0;
            Empresa = string.Empty;
            AreaAtu = string.Empty;
            AnoInicio = string.Empty;
            AnoTermino = string.Empty;
            Descricao = string.Empty;
        }
    }
}
