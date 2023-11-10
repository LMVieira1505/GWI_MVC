using System.ComponentModel.DataAnnotations;

namespace GWI.Models
{
    public class Emails
    {
        private int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres.")]
        private string ComecoEmail { get; set; }


        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres.")]
        private string FinalEmail { get; set; }

        public Emails()
        {
            Id = 0;
            ComecoEmail = string.Empty;
            FinalEmail = string.Empty;
        }
    }
}
