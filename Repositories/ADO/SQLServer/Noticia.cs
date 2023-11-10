using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using GWI.Models;
using static GWI.Models.Imagens.Imagem;
using static System.Net.Mime.MediaTypeNames;

namespace GWI.Repositories.ADO.SQLServer
{
    public class Noticia
    { 
            private readonly string connectionString; //Declarado para toda a classe. Possível alterar somente no construtor.
            public Noticia(string connectionString) //Quem invocar o construtor do repositório deve enviar a string de conexão.
            {
                this.connectionString = connectionString; //atualização do atributo por meio do valor que veio no parâmetro do construtor..
            }

            public void add(Models.Noticias noticias)
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "insert into noticias (nt_titulo, nt_subtitulo, nt_texto, nt_data_publicação, nt_ativo, nt_cat_id, nt_sct_id, nt_p_id) values (@Baldan e Marchesan abrem falência,@url da imagem ,@,@valor); select convert(int,@@identity) as id;;";

                        command.Parameters.Add(new SqlParameter("@nt_titulo", System.Data.SqlDbType.VarChar)).Value = noticias.nt_titulo;
                        command.Parameters.Add(new SqlParameter("@nt_subtitulo", System.Data.SqlDbType.VarChar)).Value = noticias.nt_subtitulo;
                        command.Parameters.Add(new SqlParameter("@nt_texto", System.Data.SqlDbType.Text)).Value = noticias.nt_texto;
                        command.Parameters.Add(new SqlParameter("@nt_data_publicação", System.Data.SqlDbType.DateTime)).Value = noticias.nt_data_publicação;
                        command.Parameters.Add(new SqlParameter("@nt_ativo", System.Data.SqlDbType.Bit)).Value = noticias.nt_ativo;
                        command.Parameters.Add(new SqlParameter("@nt_cat_id", System.Data.SqlDbType.Int)).Value = noticias.nt_cat_id;
                        command.Parameters.Add(new SqlParameter("@nt_sct_id", System.Data.SqlDbType.Int)).Value = noticias.nt_sct_id;
                        command.Parameters.Add(new SqlParameter("@nt_p_id", System.Data.SqlDbType.Int)).Value = noticias.nt_p_id;

                        noticias.nt_id = (int)command.ExecuteScalar(); // o homem do saco leva os dados até o sgbd e volta com o valor do id => ExecuteScalar retorna um único valor. Observe que o CommandText foi alterado com mais uma instrução. Então, as duas instruções são executadas e temos como retorno o valor do id que foi gerado pelo sgbd na tabela carro. Assim, conseguimos atualizar o valor do id do objeto carro que antes da inserção era 0.
                    }
                }
            }

            public List<Models.Noticias> get()
            {
                List<Models.Noticias    > noticia = new List<Models.Noticias >();

                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "select nt_id, nt_titulo, nt_subtitulo, nt_texto, nt_data_publicação, nt_ativo, nt_cat_id, nt_sct_id, nt_p_id from noticia;";
                   
                        SqlDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            Models.Noticias noticias = new Models.Noticias();
                            noticias.nt_id = (int)dr["id"];
                            noticias.nt_titulo = dr["titulo"].ToString();
                            noticias.nt_subtitulo = (string)dr["subtitulo"];
                            noticias.nt_data_publicação = (DateTime)dr["datapublicação"];
                            noticias.nt_ativo = (bool)dr["ativo"];
                            noticias.nt_cat_id = (int)dr["idcategoria"];
                            noticias.nt_sct_id = (int)dr["idsubcategoria"];
                            noticias.nt_p_id = (int)dr["idpessoa"];
                            noticias.Add(noticias);
                        }
                    }
                }

                return carros;
            }

            public void delete(int id)
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "delete from carro where id = @id;";
                        command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                        command.ExecuteNonQuery();
                    }
                }
            }

            public Models.Carro getById(int id) //somente 1 carro.
            {
                Models.Carro carro = new Models.Carro();

                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "select id, nome, cor, dataFabricacao, valor from carro where id=@id;";
                        command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.Read())
                        {
                            carro.Id = (int)dr["id"];
                            carro.Nome = dr["nome"].ToString();
                            carro.Cor = (string)dr["cor"];
                            carro.DataFabricacao = (DateTime)dr["dataFabricacao"];
                            carro.Valor = (decimal)dr["valor"];
                        }
                    }
                }

                return servico;
            }

            public void update(int id, Models.Carro carro)
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "update carro set nome = @nome, cor = @cor, dataFabricacao = @dataFabricacao, valor = @valor where id=@id;";

                        command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = carro.Nome;
                        command.Parameters.Add(new SqlParameter("@cor", System.Data.SqlDbType.VarChar)).Value = carro.Cor;
                        command.Parameters.Add(new SqlParameter("@datafabricacao", System.Data.SqlDbType.Date)).Value = carro.DataFabricacao;
                        command.Parameters.Add(new SqlParameter("@valor", System.Data.SqlDbType.Decimal)).Value = carro.Valor;
                        command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
