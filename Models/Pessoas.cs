using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWI.Models
{
    public class Pessoas
    {
        public string p_senha { get; set; }

        public bool p_ativo;
        public int p_id { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 50 caracteres.")]
        public string p_nome { get; set; }

        [Required(ErrorMessage = "Campo Sobrenome obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 50 caracteres.")]
        public string p_sobrenome { get; set; }

        [Required(ErrorMessage = "Campo telefone obrigatório", AllowEmptyStrings = false)]
        [StringLength(12, MinimumLength = 11, ErrorMessage = "Mínimo de 11 e máximo de 12 caracteres.")]
        public string p_telefone { get; set; }

        [Required(ErrorMessage = "Campo email obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mínimo de 6 e máximo de 50 caracteres.")]
        public string p_email { get; set; }

        public int p_nv_id { get; set; }

        public string p_username { get; set; }

        public Pessoas()
        {
            p_senha = string.Empty;
            p_ativo = false;
            p_id = 0;
            p_nome = string.Empty;
            p_sobrenome = string.Empty;
            p_telefone = string.Empty;
            p_email = string.Empty;
            p_ativo = true;
            p_username = string.Empty;
            p_nv_id = 4;
        }
    }
}