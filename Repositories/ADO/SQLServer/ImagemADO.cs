using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using GWI.Models;


namespace GWI.Repositories.ADO.SQLServer
{
    public class ImagemADO
    {
        private readonly string connectionString; 
        public ImagemADO(string connectionString)
        { 
            this.connectionString = connectionString;
        }

        public void add(Models.Imagens imagens)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into tb_imagens (im_url) values (@im_url); select convert(int,@@identity) as im_id;;";

                    command.Parameters.Add(new SqlParameter("@im_url", System.Data.SqlDbType.VarChar)).Value = imagens.im_url;
              
                    imagens.im_id = (int)command.ExecuteScalar(); 
                }
            }
        }

        public List<Models.Imagens> get()
        {
            List<Models.Imagens> imagem = new List<Models.Imagens>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select im_id, im_url from tb_imagens;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Imagens imagens = new Models.Imagens();
                        imagens.im_id = (int)dr["im_id"];
                        imagens.im_url = (string)dr["im_url"];
                        imagem.Add(imagens);
                    }
                }
            }

            return imagem;
        }

        public void delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete from tb_imagens where im_id = @im_id;";
                    command.Parameters.Add(new SqlParameter("@im_id", System.Data.SqlDbType.Int)).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public Models.Imagens getById(int id) 
        {
            Models.Imagens imagens = new Models.Imagens();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select im_id, im_url from tb_imagens where im_id=@im_id;";
                    command.Parameters.Add(new SqlParameter("@im_id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        imagens.im_id = (int)dr["im_id"];
                        imagens.im_url = (string)dr["im_url"];
                    }
                }
            }

            return imagens;
        }

        public void update(int id, Models.Imagens imagens)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update tb_imagens set im_url = @im_url  where im_id=@im_id;";

                    command.Parameters.Add(new SqlParameter("@im_url", System.Data.SqlDbType.VarChar)).Value = imagens.im_url;
                    
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}