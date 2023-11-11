using System.ComponentModel.DataAnnotations;

namespace GWI.Models
{
    public class Servicos

    {
        public int sv_id { get; set; }
        public List<int> sv_imagem { get; set; }

        [Required(ErrorMessage = "Campo título obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 50 caracteres.")]
        public string sv_título { get; set; }

        [Required(ErrorMessage = "Campo texto obrigatório", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 500 caracteres.")]
        public string sv_descrição { get; set; }

        public Servicos()
        {
            sv_id = 0;
            sv_título = string.Empty;
            sv_imagem = new List<int>();
            sv_descrição = string.Empty;
        }

    }
}

