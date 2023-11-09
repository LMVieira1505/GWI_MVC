using System.ComponentModel.DataAnnotations;

namespace GWI.Models.Servico.Model
{
    public class Servicos

    {
        private int Autor_Id_pess { get; set; }
        private List<int> Id_img { get; set; }

        private bool Ativo;

        [Required(ErrorMessage = "Campo título obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 50 caracteres.")]
        private string Titulo { get; set; }

        [Required(ErrorMessage = "Campo subtítulo obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 50 caracteres.")]
        private string Subtitulo { get; set; }
          

        [Required(ErrorMessage = "Campo texto obrigatório", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 500 caracteres.")]
        private string Texto { get; set; }
          
        [Required]
        [Display(Name = "Data de Publicação")]
        private DateTime Data_Pub { get; set; }

        public Servicos() 
        {
            Autor_Id_pess = 0;
            Id_img = new List<int>();
            Ativo = false;
            Titulo = string.Empty;
            Subtitulo = string.Empty;
            Texto = string.Empty;
            Data_Pub = DateTime.Now;
        }   
        
    }
}

