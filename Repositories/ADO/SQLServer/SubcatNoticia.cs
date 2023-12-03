using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using GWI.Models.Noticias;

namespace GWI.Repositories.ADO.SQLServer
{
    public class SubcatNoticiaADO
    {
        private readonly string connectionString; //Declarado para toda a classe. Possível alterar somente no construtor.
        public SubcatNoticiaADO(string connectionString) //Quem invocar o construtor do repositório deve enviar a string de conexão.
        {
            this.connectionString = connectionString; //atualização do atributo por meio do valor que veio no parâmetro do construtor..
        }

        public List<Subcategoria> GetAll()
        {
            List<Subcategoria> SubcatNoticias = new List<Subcategoria>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select sctnt_id, sctnt_nt_id, sbtnt_sct_id from tb_sctnt;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Subcategoria SubcatNoticia = new Subcategoria();
                        SubcatNoticia.sctnt_id = (int)dr["cat_id"];
                        SubcatNoticia.sctnt_nt_id = (int)dr["cat_id"];
                        SubcatNoticia.sbtnt_sct_id = (int)dr["cat_id"];
                        SubcatNoticias.Add(SubcatNoticia);
                    }
                }
            }

            return SubcatNoticias;
        }

    }
}
