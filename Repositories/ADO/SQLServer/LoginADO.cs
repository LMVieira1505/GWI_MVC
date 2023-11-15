using Microsoft.Data.SqlClient;
using GWI.Models;

namespace GWI.Repositories.ADO.SQLServer
{
    public class LoginADO
    {
        private readonly string connectionString;

        public LoginADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool check(Login login)
        {

            bool result = false;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id from pessoas where usuario=@usuario and senha=@senha"; 
                    command.Parameters.Add(new SqlParameter("@usuario", System.Data.SqlDbType.VarChar)).Value = login.Email;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = login.Senha;
                    command.Parameters.Add(new SqlParameter("@Tipo", System.Data.SqlDbType.Int)).Value=login.tipoUser;

                    SqlDataReader dr = command.ExecuteReader();
                    result = dr.Read();
                }
            }

            return result;
        }

        public LoginResultado getType(Login login)
        {
            LoginResultado result = new LoginResultado();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id, tipo from pessoas where usuario=@usuario and senha=@senha";
                    command.Parameters.Add(new SqlParameter("@usuario", System.Data.SqlDbType.VarChar)).Value = login.Email;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = login.Senha;

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        result.Sucesso = dr.Read();

                        if (result.Sucesso)
                        { 
                            result.TipoUsuario = dr["tipo"].ToString();

                            login.tipoUser = result.TipoUsuario;
                        }
                    }

                }
            }
            return result;
        }
    }
}

