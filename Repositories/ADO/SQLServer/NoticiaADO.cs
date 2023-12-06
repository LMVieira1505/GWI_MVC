using GWI.Models.Imagens;
using GWI.Models.Noticias;
using GWI.Models.Pessoas;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
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

        // CRUD Notícia //
        #region
        public void add(Noticias noticias)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT into tb_noticias (nt_titulo, nt_subtitulo, nt_texto, nt_data_publicacao, nt_ativo, nt_cat_id, nt_p_id) values (@nt_titulo, @nt_subtitulo, @nt_texto, @nt_data_publicacao, @nt_ativo, @nt_cat_id, @nt_p_id); select convert(int,@@identity) as id;;";

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

        public NoticiaImagemAutor GetById(int id)
        {
            NoticiaImagemAutor noticia = new NoticiaImagemAutor();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select nt_id, nt_titulo, nt_subtitulo, nt_texto, nt_data_publicacao, nt_ativo, nt_cat_id, nt_p_id, p_username, imn_capa, im_url FROM tb_noticias INNER JOIN tb_pessoas ON tb_noticias.nt_p_id = tb_pessoas.p_id INNER JOIN tb_img_not ON tb_noticias.nt_id = tb_img_not.imn_nt_id INNER JOIN tb_imagens ON tb_img_not.imn_im_id = tb_imagens.im_id where nt_id=@nt_id;";
                    command.Parameters.Add(new SqlParameter("@nt_id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        noticia.nt_id = (int)dr["nt_id"];
                        noticia.nt_titulo = (string)dr["nt_titulo"];
                        noticia.nt_subtitulo = (string)dr["nt_subtitulo"];
                        noticia.nt_texto = (string)dr["nt_texto"];
                        noticia.nt_data_publicacao = (DateTime)dr["nt_data_publicacao"];
                        noticia.p_username = (string)dr["p_username"];
                        noticia.imn_capa = (bool)dr["imn_capa"];
                        noticia.im_url = (string)dr["im_url"];
                    }
                }
            }

            return noticia;
        }

        public List<NoticiaImagemAutor> get()
        {
            List<NoticiaImagemAutor> noticia = new List<NoticiaImagemAutor>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT nt_id, nt_titulo, nt_subtitulo, nt_texto, nt_data_publicacao, p_username, imn_capa, im_url FROM tb_noticias INNER JOIN tb_pessoas ON tb_noticias.nt_p_id = tb_pessoas.p_id INNER JOIN tb_img_not ON tb_noticias.nt_id = tb_img_not.imn_nt_id INNER JOIN tb_imagens ON tb_img_not.imn_im_id = tb_imagens.im_id where nt_ativo=1;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        NoticiaImagemAutor noticias = new NoticiaImagemAutor();
                        noticias.nt_id = (int)dr["nt_id"];
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

        public void delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE tb_noticias SET nt_ativo = 0 WHERE nt_id=@nt_id;";
                    command.Parameters.Add(new SqlParameter("@nt_id", System.Data.SqlDbType.Int)).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void update(int id, Noticias noticias)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE tb_noticias SET nt_titulo = @nt_titulo, nt_subtitulo = @nt_subtitulo, nt_texto = @nt_texto, nt_data_publicacao = @nt_data_publicacao, nt_ativo = @nt_ativo, nt_cat_id = @nt_cat_id, nt_p_id = @nt_p_id WHERE nt_id = @nt_id;";

                    command.Parameters.Add(new SqlParameter("@nt_id", System.Data.SqlDbType.Int)).Value = id;
                    command.Parameters.Add(new SqlParameter("@nt_titulo", System.Data.SqlDbType.VarChar)).Value = noticias.nt_titulo;
                    command.Parameters.Add(new SqlParameter("@nt_subtitulo", System.Data.SqlDbType.VarChar)).Value = noticias.nt_subtitulo;
                    command.Parameters.Add(new SqlParameter("@nt_texto", System.Data.SqlDbType.Text)).Value = noticias.nt_texto;
                    command.Parameters.Add(new SqlParameter("@nt_data_publicacao", System.Data.SqlDbType.DateTime)).Value = noticias.nt_data_publicacao;
                    command.Parameters.Add(new SqlParameter("@nt_ativo", System.Data.SqlDbType.Bit)).Value = noticias.nt_ativo;
                    command.Parameters.Add(new SqlParameter("@nt_cat_id", System.Data.SqlDbType.Bit)).Value = noticias.nt_cat_id;
                    command.Parameters.Add(new SqlParameter("@nt_p_id", System.Data.SqlDbType.Bit)).Value = noticias.nt_p_id;


                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion


        // Categorias //
        #region
        public List<Categorias> GetCategorias()
        {
            List<Categorias> categorias = new List<Categorias>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT cat_id, cat_nome, cat_ativo FROM tb_categorias;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Categorias categoria = new Categorias();
                        categoria.cat_id = (int)dr["cat_id"];
                        categoria.cat_nome = (string)dr["cat_nome"];
                        categoria.cat_ativo = (bool)dr["cat_ativo"];
                        categorias.Add(categoria);
                    }
                }
            }

            return categorias;
        }

        #endregion

        // Subcategorias //
        #region

        public List<Subcategorias> GetSubcategorias()
        {
            List<Subcategorias> subcategorias = new List<Subcategorias>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT sct_id, sct_nome, sct_ativo, sct_cat_id FROM tb_subcategorias;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Subcategorias subcategoria = new Subcategorias();
                        subcategoria.sct_id = (int)dr["sct_id"];
                        subcategoria.sct_nome = (string)dr["sct_nome"];
                        subcategoria.sct_ativo = (bool)dr["sct_ativo"];
                        subcategoria.sct_cat_id = (int)dr["sct_cat_id"];
                        subcategorias.Add(subcategoria);
                    }
                }
            }

            return subcategorias;
        }

        #endregion

        // Imagens //
        #region

        public List<Imagens> GetImagens()
        {
            List<Imagens> imagens = new List<Imagens>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT im_id, im_url FROM tb_imagens;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Imagens imagem = new Imagens();
                        imagem.im_id = (int)dr["im_id"];
                        imagem.im_url = (string)dr["im_url"];
                        imagens.Add(imagem);
                    }
                }
            }

            return imagens;
        }
        #endregion
    }
}