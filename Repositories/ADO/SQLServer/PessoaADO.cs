using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using GWI.Models;

namespace GWI.Repositories.ADO.SQLServer
{
    public class PessoaADO
    {
        private readonly string connectionString; //Declarado para toda a classe. Possível alterar somente no construtor.
        public PessoaADO(string connectionString) //Quem invocar o construtor do repositório deve enviar a string de conexão.
        {
            this.connectionString = connectionString; //atualização do atributo por meio do valor que veio no parâmetro do construtor..
        }

        public void add(Models.Pessoas pessoas)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into pessoas (p_senha, p_ativo, p_nome, p_sobrenome, p_telefone, p_email) values (@Baldan e Marchesan abrem falência,@url da imagem ,@,@valor); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@p_senha", System.Data.SqlDbType.VarChar)).Value = pessoas.p_senha;
                    command.Parameters.Add(new SqlParameter("@p_ativo", System.Data.SqlDbType.Bit)).Value = pessoas.p_ativo;
                    command.Parameters.Add(new SqlParameter("@p_nome", System.Data.SqlDbType.VarChar)).Value = pessoas.p_nome;
                    command.Parameters.Add(new SqlParameter("@p_sobrenome", System.Data.SqlDbType.VarChar)).Value = pessoas.p_sobrenome;
                    command.Parameters.Add(new SqlParameter("@p_telefone", System.Data.SqlDbType.VarChar)).Value = pessoas.p_telefone;
                    command.Parameters.Add(new SqlParameter("@p_email", System.Data.SqlDbType.VarChar)).Value = pessoas.p_email;

                    pessoas.p_id = (int)command.ExecuteScalar(); // o homem do saco leva os dados até o sgbd e volta com o valor do id => ExecuteScalar retorna um único valor. Observe que o CommandText foi alterado com mais uma instrução. Então, as duas instruções são executadas e temos como retorno o valor do id que foi gerado pelo sgbd na tabela carro. Assim, conseguimos atualizar o valor do id do objeto carro que antes da inserção era 0.
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
                    command.CommandText = "select p_id, p_senha, p_ativo, p_nome, p_sobrenome, p_telefone, p_email from pessoas;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Pessoas pessoas = new Models.Pessoas();
                        pessoas.p_id = (int)dr["id"];
                        pessoas.p_senha = (string)dr["senha"];
                        pessoas.p_ativo = (bool)dr["ativo"];
                        pessoas.p_nome = (string)dr["nome"];
                        pessoas.p_sobrenome = (string)dr["sobrenome"];
                        pessoas.p_telefone = (string)dr["telefone"];
                        pessoas.p_email = (string)dr["email"];

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

        public Models.Pessoas getById(int id) //somente 1 carro.
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
    }
}

