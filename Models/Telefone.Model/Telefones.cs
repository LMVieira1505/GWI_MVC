using System.ComponentModel.DataAnnotations;

namespace GWI.Models.Telefone.Model
{
    public class Telefones
    {
        private int Id { get; set; }

        [Required(ErrorMessage = "Campo DDD obrigatório", AllowEmptyStrings = false)]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "Mínimo de 2 e máximo de 4 caracteres.")]
        private string DDD { get; set; }

        [Required(ErrorMessage = "Campo Número obrigatório", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 9, ErrorMessage = "Mínimo de 9 e máximo de 10 caracteres.")]
        private string Numero { get; set; }

        public Telefones()
        {
            Id = 0;
            DDD = string.Empty;
            Numero = string.Empty;
        }
       
    }
}
