using System.ComponentModel.DataAnnotations;

namespace GWI.Models
{
    public class Servicos

    {
        private int Id { get; set; }
        private List<int> Id_img { get; set; }

        [Required(ErrorMessage = "Campo título obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 50 caracteres.")]
        private string Titulo { get; set; }

        [Required(ErrorMessage = "Campo texto obrigatório", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 500 caracteres.")]
        private string Descricao { get; set; }

        public Servicos()
        {
            Id = 0;
            Titulo = string.Empty;
            Id_img = new List<int>();
            Descricao = string.Empty;
        }

    }
}

