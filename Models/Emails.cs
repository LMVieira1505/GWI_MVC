using System.ComponentModel.DataAnnotations;

namespace GWI.Models
{
    public class Emails
    {
        public int em_id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres.")]
        public string em_email { get; set; }

        

        public Emails()
        {
            em_id = 0;
            em_email = string.Empty;
            
        }
    }
}
