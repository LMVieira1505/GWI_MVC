using System.ComponentModel.DataAnnotations;

namespace GWI.Models.Noticia.Model
{
    public class Noticias
    { 
        private int Id_not { get; set; }
        private int Id_categoria { get; set; }
        private List<int> Id_subcategoria { get; set; }
        private int Autor_Id_pess { get; set; }
        private List<int> Id_img { get; set; }
        private bool Ativo;

        [Required(ErrorMessage = "Campo título obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 50 caracteres.")]
        private string Titulo { get; set; }

        [Required(ErrorMessage = "Campo subtítulo obrigatório", AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 40 caracteres.")]
        private string Subtitulo { get; set; }
       
        [Required(ErrorMessage = "Campo texto obrigatório", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 500 caracteres.")]
        private string Texto { get; set; }

        [Required]
        [Display(Name = "Data de Publicação")]
        private DateTime Data_Pub { get; set; }

        public Noticias()
        {
            Id_not = 0;
            Id_categoria = 0;
            Id_subcategoria = new List<int>();
            Id_img = new List<int>();
            Autor_Id_pess = 0;
            Ativo = false;
            Titulo = string.Empty;
            Subtitulo = string.Empty;
            Texto = string.Empty;
            Data_Pub = DateTime.Now;
        }
    }
}
