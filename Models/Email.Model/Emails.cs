using System.ComponentModel.DataAnnotations;

namespace GWI.Models.Email.Model
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

        public Emails ()
        {
            this.Id= 0;
            this.ComecoEmail = string.Empty;
            this.FinalEmail = string.Empty;
        }
    }
}
