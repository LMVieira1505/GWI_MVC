using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWI.Models
{
    public class Imagens
    {
        public int im_id { get; set; }

        [Required(ErrorMessage = "Campo caminho da imagem obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 200 caracteres.")]
        public string im_url { get; set; }
        public Imagens()
        {
            im_id = 0;
            im_url = string.Empty;
        }
    }
}
