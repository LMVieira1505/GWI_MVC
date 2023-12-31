﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWI.Models.Pessoas
{
    public class Login
    {
        [Required(ErrorMessage = "Campo Usuário obrigatório", AllowEmptyStrings = false)]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Mínimo de 10 e máximo de 30 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha obrigatório", AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Mínimo de 6 e máximo de 15 caracteres.")]
        public string Senha { get; set; }


        [Required(ErrorMessage = "Campo Tipo do Usuário obrigatório", AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 15 caracteres.")]
        public string tipoUser { get; set; }
        public Login()
        {
            Email = "";
            Senha = "";
            tipoUser = string.Empty;
        }
    }
}
