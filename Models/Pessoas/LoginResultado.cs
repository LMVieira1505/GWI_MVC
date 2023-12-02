using Microsoft.Extensions.WebEncoders.Testing;

namespace GWI.Models.Pessoas
{
    public class LoginResultado
    {

        public bool Sucesso { get; set; }
        public int Id { get; set; }
        public int TipoUsuario { get; set; }

        public LoginResultado()
        {
            Id = 0;
            TipoUsuario = 0;
        }

    }
}