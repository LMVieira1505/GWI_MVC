//using System.ComponentModel.DataAnnotations;

//namespace GWI.Models
//{
//    public class ExpsProfs
//    {

//        public int exp_id { get; set; }

//        [Required(ErrorMessage = "Campo texto obrigatório", AllowEmptyStrings = false)]
//        [StringLength(500, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 500 caracteres.")]
//        public string exp_empresa { get; set; }

//        [Required(ErrorMessage = "Campo área de atuação obrigatório", AllowEmptyStrings = false)]
//        [StringLength(20, MinimumLength = 5, ErrorMessage = "Mínimo de 5 e máximo de 20 caracteres.")]
//        public string exp_area { get; set; }

//        [Required(ErrorMessage = "Campo ano de início obrigatório", AllowEmptyStrings = false)]
//        [StringLength(10, MinimumLength = 4, ErrorMessage = "Mínimo de 4 e máximo de 10 caracteres.")]
//        public string exp_ano_ini { get; set; }

//        [Required(ErrorMessage = "Campo ano de término obrigatório", AllowEmptyStrings = false)]
//        [StringLength(10, MinimumLength = 4, ErrorMessage = "Mínimo de 4 e máximo de 10 caracteres.")]
//        public string exp_ano_ter { get; set; }

//        [Required(ErrorMessage = "Campo descrição obrigatório", AllowEmptyStrings = false)]
//        [StringLength(200, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 200 caracteres.")]
//        public string exp_descricao { get; set; }

        

//        public ExpsProfs()
//        {

//            exp_id = 0;
//            exp_empresa = string.Empty;
//            exp_area = string.Empty;
//            exp_ano_ini = string.Empty;
//            exp_ano_ter = string.Empty;
//            exp_descricao = string.Empty;
           
//        }
//    }
//}
