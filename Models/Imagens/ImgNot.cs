using System.ComponentModel.DataAnnotations;

namespace GWI.Models.Imagens
{
    public class ImgNot
    {
        public int imn_id;
        public int imn_im_id;
        public int imn_nt_id;

        [Required(ErrorMessage = "Campo capa obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres.")]

        public string imn_capa;

        public ImgNot() 
        {
            imn_id = 0;
            imn_im_id = 0;
            imn_nt_id = 0;
            imn_capa = string.Empty;
        }

    }
}
