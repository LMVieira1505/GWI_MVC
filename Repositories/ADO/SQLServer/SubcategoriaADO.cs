using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using GWI.Models.Noticias;

namespace GWI.Repositories.ADO.SQLServer
{
    public class SubcategoriaADO
    {
        private readonly string connectionString; //Declarado para toda a classe. Possível alterar somente no construtor.
        public SubcategoriaADO(string connectionString) //Quem invocar o construtor do repositório deve enviar a string de conexão.
        {
            this.connectionString = connectionString; //atualização do atributo por meio do valor que veio no parâmetro do construtor..
        }

        
    }
}
