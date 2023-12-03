using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using GWI.Models.Noticias;

namespace GWI.Repositories.ADO.SQLServer
{
    public class CategoriaADO
    {
        private readonly string connectionString; //Declarado para toda a classe. Possível alterar somente no construtor.
        public CategoriaADO(string connectionString) //Quem invocar o construtor do repositório deve enviar a string de conexão.
        {
            this.connectionString = connectionString; //atualização do atributo por meio do valor que veio no parâmetro do construtor..
        }

        public List<Categorias> GetAll()
        {
            List<Categorias> categorias = new List<Categorias>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select cat_id, cat_nome, cat_ativo from tb_categorias;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Categorias categoria = new Categorias();
                        categoria.cat_id = (int)dr["cat_id"];
                        categoria.cat_nome = (string)dr["cat_nome"];
                        categoria.cat_ativo  = (bool)dr["cat_ativo"];
                        categorias.Add(categoria);
                    }
                }
            }

            return categorias;
        }

    }
}
