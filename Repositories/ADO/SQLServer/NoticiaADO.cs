﻿using Microsoft.AspNetCore.Identity;
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
                    command.CommandText = "insert into noticias (nt_titulo, nt_subtitulo, nt_texto, nt_data_publicação, nt_ativo, nt_cat_id, nt_sct_id, nt_p_id) values (@nt_titulo, @nt_subtitulo, nt_texto, nt_data_publicação, nt_ativo, nt_cat_id, nt_sct_id, nt_p_id); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@nt_titulo", System.Data.SqlDbType.VarChar)).Value = noticias.nt_titulo;
                    command.Parameters.Add(new SqlParameter("@nt_subtitulo", System.Data.SqlDbType.VarChar)).Value = noticias.nt_subtitulo;
                    command.Parameters.Add(new SqlParameter("@nt_texto", System.Data.SqlDbType.Text)).Value = noticias.nt_texto;
                    command.Parameters.Add(new SqlParameter("@nt_data_publicação", System.Data.SqlDbType.DateTime)).Value = noticias.nt_data_publicação;
                    command.Parameters.Add(new SqlParameter("@nt_ativo", System.Data.SqlDbType.Bit)).Value = noticias.nt_ativo;
                    command.Parameters.Add(new SqlParameter("@nt_cat_id", System.Data.SqlDbType.Int)).Value = noticias.nt_cat_id;
                    command.Parameters.Add(new SqlParameter("@nt_sct_id", System.Data.SqlDbType.Int)).Value = noticias.nt_sct_id;
                    command.Parameters.Add(new SqlParameter("@nt_p_id", System.Data.SqlDbType.Int)).Value = noticias.nt_p_id;

                    noticias.nt_id = (int)command.ExecuteScalar(); 
                }
            }
        }

        public List<Models.Noticias> get()
        {
            List<Models.Noticias> noticia = new List<Models.Noticias>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select nt_id, nt_titulo, nt_subtitulo, nt_texto, nt_data_publicação, nt_ativo, nt_cat_id, nt_sct_id, nt_p_id from noticias;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Noticias noticias = new Models.Noticias();
                        noticias.nt_id = (int)dr["id"];
                        noticias.nt_titulo = (string)dr["titulo"];
                        noticias.nt_subtitulo = (string)dr["subtitulo"];
                        noticias.nt_data_publicação = (DateTime)dr["datapublicação"];
                        noticias.nt_ativo = (bool)dr["ativo"];
                        noticias.nt_cat_id = (int)dr["idcategoria"];
                        noticias.nt_sct_id = (int)dr["idsubcategoria"];
                        noticias.nt_p_id = (int)dr["idpessoa"];
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
                    command.CommandText = "select nt_id, nt_titulo, nt_subtitulo, nt_texto, nt_data_publicação, nt_ativo, nt_cat_id, nt_sct_id, nt_p_id from noticias where id=@id;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        noticia.nt_id = (int)dr["id"];
                        noticia.nt_titulo = (string)dr["nome"];
                        noticia.nt_subtitulo = (string)dr["cor"];
                        noticia.nt_texto = (string)dr["texto"];
                        noticia.nt_data_publicação = (DateTime)dr["datapublicação"];
                        noticia.nt_ativo = (bool)dr["ativo"];
                        noticia.nt_cat_id = (int)dr["idcategoria"];
                        noticia.nt_sct_id = (int)dr["idsubcategoria"];
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