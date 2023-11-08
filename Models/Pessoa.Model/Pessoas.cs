namespace GWI.Models.Pessoa.Model
{
    public class Pessoas
    {
        public abstract class Pessoa
        {
            private int Id_pess { get; set; }
            private string Nome { get; set; }
            private string Sobrenome { get; set; }
            private List<string> Telefone { get; set; }
            private List<string> Email { get; set; }
            private string Senha { get; set; }

            private bool Ativo;
            public class Usuario : Pessoa
            {

            }

            public class Administrador : Pessoa
            {

            }

            public class Autor : Pessoa
            {
                private string Cidade { get; set; }
            }
        }
    }
}
