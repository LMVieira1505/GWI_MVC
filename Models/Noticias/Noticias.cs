﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GWI.Models.Noticias
{
    public class Noticias
    {
        public int nt_id { get; set; }
        public int nt_cat_id { get; set; }
        public int nt_p_id { get; set; }

        public bool nt_ativo;

        public List<int> nt_subcategorias { get; set; }

        [Required(ErrorMessage = "Campo título obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 50 caracteres.")]
        public string nt_titulo { get; set; }

        [Required(ErrorMessage = "Campo subtítulo obrigatório", AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 40 caracteres.")]
        public string nt_subtitulo { get; set; }

        [Required(ErrorMessage = "Campo texto obrigatório", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 500 caracteres.")]
        public string nt_texto { get; set; }

        [Required]
        [Display(Name = "Data de Publicação")]
        public DateTime nt_data_publicacao { get; set; }

        public Noticias()
        {
            nt_id = 0;
            nt_titulo = string.Empty;
            nt_subtitulo = string.Empty;
            nt_texto = string.Empty;
            nt_data_publicacao = DateTime.Now;
            nt_ativo = true;
            nt_cat_id = 0;
            nt_p_id = 0;
        }
    }
}
