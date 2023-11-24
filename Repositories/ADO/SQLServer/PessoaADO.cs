using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using GWI.Models;

namespace GWI.Repositories.ADO.SQLServer
{
    public class PessoaADO
    {
        private readonly string connectionString; 
        public PessoaADO(string connectionString) 
        {
            this.connectionString = connectionString; 
        }

        public void add(Models.Pessoas pessoas)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO tb_pessoas (p_senha, p_ativo, p_nome, p_sobrenome, p_telefone, p_email, p_nv_id, p_username) VALUES (@p_senha, @p_ativo, @p_nome, @p_sobrenome, @p_telefone, @p_email, @p_nv_id, @p_username); select convert(int, @@identity) as id;";

                    command.Parameters.Add(new SqlParameter("@p_senha", System.Data.SqlDbType.VarChar)).Value = pessoas.p_senha;
                    command.Parameters.Add(new SqlParameter("@p_ativo", System.Data.SqlDbType.Bit)).Value = pessoas.p_ativo;
                    command.Parameters.Add(new SqlParameter("@p_nome", System.Data.SqlDbType.VarChar)).Value = pessoas.p_nome;
                    command.Parameters.Add(new SqlParameter("@p_sobrenome", System.Data.SqlDbType.VarChar)).Value = pessoas.p_sobrenome;
                    command.Parameters.Add(new SqlParameter("@p_telefone", System.Data.SqlDbType.VarChar)).Value = pessoas.p_telefone;
                    command.Parameters.Add(new SqlParameter("@p_email", System.Data.SqlDbType.VarChar)).Value = pessoas.p_email;
                    command.Parameters.Add(new SqlParameter("@p_nv_id", System.Data.SqlDbType.Int)).Value = pessoas.p_nv_id;
                    command.Parameters.Add(new SqlParameter("@p_username", System.Data.SqlDbType.VarChar)).Value = pessoas.p_username;

                    pessoas.p_id = (int)command.ExecuteScalar(); 
                }
            }
        }

        public List<Models.Pessoas> get()
        {
            List<Models.Pessoas> pessoa = new List<Models.Pessoas>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select p_id, p_senha, p_ativo, p_nome, p_sobrenome, p_telefone, p_email, p_username, p_nv_id, p_ativo from tb_pessoas;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Pessoas pessoas = new Models.Pessoas();
                        pessoas.p_id = (int)dr["p_id"];
                        pessoas.p_senha = (string)dr["p_senha"];
                        pessoas.p_ativo = (bool)dr["p_ativo"];
                        pessoas.p_nome = (string)dr["p_nome"];
                        pessoas.p_sobrenome = (string)dr["p_sobrenome"];
                        pessoas.p_telefone = (string)dr["p_telefone"];
                        pessoas.p_email = (string)dr["p_email"];
                        pessoas.p_username = (string)dr["p_username"];
                        pessoas.p_nv_id = (int)dr["p_nv_id"];
                        pessoas.p_ativo = (bool)dr["p_ativo"];

                        pessoa.Add(pessoas);
                    }
                }
            }

            return pessoa;
        }

        public void delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete from pessoas where id = @id;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public Models.Pessoas getById(int id) 
        {
            Models.Pessoas pessoa = new Models.Pessoas();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select p_id, p_senha, p_ativo, p_nome, p_sobrenome, p_telefone, p_email from pessoas where id=@id;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        pessoa.p_id = (int)dr["id"];
                        pessoa.p_senha = (string)dr["senha"];
                        pessoa.p_ativo = (bool)dr["ativo"];
                        pessoa.p_nome = (string)dr["nome"];
                        pessoa.p_sobrenome = (string)dr["sobrenome"];
                        pessoa.p_telefone = (string)dr["telefone"];
                        pessoa.p_email = (string)dr["email"];
                    }
                }
            }

            return pessoa;
        }

        public void update(int id, Models.Pessoas pessoas)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update pessoas set p_ativo = @0, where id=@id;";

                    command.Parameters.Add(new SqlParameter("@0", System.Data.SqlDbType.Bit)).Value = pessoas.p_ativo;

                    command.ExecuteNonQuery();
                }
            }
        }
        #region"Login"
        public bool check(Pessoas pessoas)
        {

            bool result = false;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select p_id from tb_pessoas where p_email = @p_email and p_senha = @p_senha";
                    command.Parameters.Add(new SqlParameter("@p_email", System.Data.SqlDbType.VarChar)).Value = pessoas.p_email;
                    command.Parameters.Add(new SqlParameter("@p_senha", System.Data.SqlDbType.VarChar)).Value = pessoas.p_senha;

                    SqlDataReader dr = command.ExecuteReader();
                    result = dr.Read();
                }
            }

            return result;
        }

        public LoginResultado getType(Pessoas pessoas)
        {
            LoginResultado result = new LoginResultado();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select p_nv_id from tb_pessoas where p_email=@p_email and p_senha=@p_senha";
                    command.Parameters.Add(new SqlParameter("@p_email", System.Data.SqlDbType.VarChar)).Value = pessoas.p_email;
                    command.Parameters.Add(new SqlParameter("@p_senha", System.Data.SqlDbType.VarChar)).Value = pessoas.p_senha;

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        result.Sucesso = dr.Read();

                        if (result.Sucesso)
                        {
                            result.TipoUsuario = (int)dr["p_nv_id"];

                            pessoas.p_nv_id = result.TipoUsuario;
                        }
                    }

                }
            }
            return result;
        }
        #endregion
    }
}

