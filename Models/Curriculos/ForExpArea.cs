﻿using System.ComponentModel.DataAnnotations;

namespace GWI.Models.Curriculos
{
    public class ForExpArea
    {
        public int fe_id { get; set; }

        [Required(ErrorMessage = "Campo Formação Acadêmica ou Experiência Profissional Obrigatório", AllowEmptyStrings = false)]
        public bool fe_tipo { get; set; }

        [Required(ErrorMessage = "Campo Título de Atuação Obrigatório", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Mínimo de 5 e máximo de 110 caracteres.")]
        public string fe_nome { get; set; }

        [Required(ErrorMessage = "Campo Texto Obrigatório", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Mínimo de 1 e máximo de 500 caracteres.")]
        public string fe_instituicao { get; set; }

        [Required(ErrorMessage = "Campo Ano de Início Obrigatório", AllowEmptyStrings = false)]
        public int fe_ano_ini { get; set; }

        [Required(ErrorMessage = "Campo Ano de Término Obrigatório", AllowEmptyStrings = false)]
        public int fe_ano_ter { get; set; }

        [Required(ErrorMessage = "Campo Descrição Obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 200 caracteres.")]
        public string fe_descricao { get; set; }

        public int fe_ar_id { get; set; }

        public int fe_p_id { get; set; }


        public int ar_id {  get; set; }
        public string ar_tipo { get; set; }
        public string ar_nome { get; set; }



        public ForExpArea()
        {
            fe_id = 0;
            fe_tipo = false;
            fe_nome = string.Empty;
            fe_instituicao = string.Empty;
            fe_ano_ini = 0;
            fe_ano_ter = 0;
            fe_descricao = string.Empty;
            fe_ar_id = 0;
            fe_p_id = 0;
            ar_id = 0;
            ar_tipo = string.Empty;
            ar_nome = string.Empty;
        }
    }
}
