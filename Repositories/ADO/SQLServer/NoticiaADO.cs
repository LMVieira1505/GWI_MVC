using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using GWI.Models;
using System.Runtime.ConstrainedExecution;


namespace GWI.Repositories.ADO.SQLServer
{
    public class NoticiaADO
    {
        private readonly string connectionString; 
        public NoticiaADO(string connectionString) 
        {
            this.connectionString = connectionString; 
        }

        public void add(Models.Noticias noticias)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into noticias (nt_titulo, nt_subtitulo, nt_texto, nt_data_publicacao, nt_ativo, nt_cat_id, nt_sct_id, nt_p_id) values (@nt_titulo, @nt_subtitulo, @nt_texto, @nt_data_publicacao, @nt_ativo, @nt_cat_id, @nt_sct_id, @nt_p_id); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@nt_titulo", System.Data.SqlDbType.VarChar)).Value = noticias.nt_titulo;
                    command.Parameters.Add(new SqlParameter("@nt_subtitulo", System.Data.SqlDbType.VarChar)).Value = noticias.nt_subtitulo;
                    command.Parameters.Add(new SqlParameter("@nt_texto", System.Data.SqlDbType.Text)).Value = noticias.nt_texto;
                    command.Parameters.Add(new SqlParameter("@nt_data_publicacao", System.Data.SqlDbType.DateTime)).Value = noticias.nt_data_publicacao;
                    command.Parameters.Add(new SqlParameter("@nt_ativo", System.Data.SqlDbType.Bit)).Value = noticias.nt_ativo;
                    command.Parameters.Add(new SqlParameter("@nt_cat_id", System.Data.SqlDbType.Int)).Value = noticias.nt_cat_id;
                    command.Parameters.Add(new SqlParameter("@nt_p_id", System.Data.SqlDbType.Int)).Value = noticias.nt_p_id;

                    noticias.nt_id = (int)command.ExecuteScalar(); 
                }
            }
        }

        public List<Models.NoticiaImagemAutor> get()
        {
            List<Models.NoticiaImagemAutor> noticia = new List<Models.NoticiaImagemAutor>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT nt_titulo, nt_subtitulo, nt_texto, nt_data_publicacao, p_username, imn_capa, im_url FROM tb_noticias INNER JOIN tb_pessoas ON tb_noticias.nt_p_id = tb_pessoas.p_id INNER JOIN tb_img_not ON tb_noticias.nt_id = tb_img_not.imn_nt_id INNER JOIN tb_imagens ON tb_img_not.imn_im_id = tb_imagens.im_id;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.NoticiaImagemAutor noticias = new Models.NoticiaImagemAutor();
                        noticias.nt_titulo = (string)dr["nt_titulo"];
                        noticias.nt_subtitulo = (string)dr["nt_subtitulo"];
                        noticias.nt_texto = (string)dr["nt_texto"];
                        noticias.nt_data_publicacao = (DateTime)dr["nt_data_publicacao"];
                        noticias.p_username = (string)dr["p_username"];
                        noticias.imn_capa = (bool)dr["imn_capa"];
                        noticias.im_url = (string)dr["im_url"];
                        noticia.Add(noticias);
                    }
                }
            }

            return noticia;
        }

        //public List<Models.Noticias> get()
        //{
        //    List<Models.Noticias> noticia = new List<Models.Noticias>();

        //    using (SqlConnection connection = new SqlConnection(this.connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandText = "select nt_id, nt_titulo, nt_subtitulo, nt_texto, nt_ativo, nt_cat_id, nt_p_id from tb_noticias;";

        //            SqlDataReader dr = command.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                Models.Noticias noticias = new Models.Noticias();
        //                noticias.nt_id = (int)dr["nt_id"];
        //                noticias.nt_titulo = (string)dr["nt_titulo"];
        //                noticias.nt_subtitulo = (string)dr["nt_subtitulo"];
        //                //noticias.nt_data_publicacao = (DateTime)dr["nt_datapublicacao"];
        //                noticias.nt_ativo = (bool)dr["nt_ativo"];
        //                noticias.nt_cat_id = (int)dr["nt_cat_id"];
        //                noticias.nt_p_id = (int)dr["nt_p_id"];
        //                noticia.Add(noticias);
        //            }
        //        }
        //    }

        //    return noticia;
        //}

        public void delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete from noticias where id = @id;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public Models.Noticias getById(int id) 
        {
            Models.Noticias noticia = new Models.Noticias();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select nt_id, nt_titulo, nt_subtitulo, nt_texto, nt_data_publicacao, nt_ativo, nt_cat_id, nt_sct_id, nt_p_id from noticias where id=@id;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        noticia.nt_id = (int)dr["id"];
                        noticia.nt_titulo = (string)dr["nome"];
                        noticia.nt_subtitulo = (string)dr["cor"];
                        noticia.nt_texto = (string)dr["texto"];
                        noticia.nt_data_publicacao = (DateTime)dr["datapublicação"];
                        noticia.nt_ativo = (bool)dr["ativo"];
                        noticia.nt_cat_id = (int)dr["idcategoria"];
                        noticia.nt_p_id = (int)dr["idpessoa"];
                    }
                }
            }

            return noticia;
        }

        public void update(int id, Models.Noticias noticias)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update noticias set nt_titulo = @Baldan, nt_subtitulo = @Baldan abre falência where id=@id;";

                    command.Parameters.Add(new SqlParameter("@Baldan", System.Data.SqlDbType.VarChar)).Value = noticias.nt_titulo;
                    command.Parameters.Add(new SqlParameter("@Baldan abre falência", System.Data.SqlDbType.VarChar)).Value = noticias.nt_subtitulo;
           
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}