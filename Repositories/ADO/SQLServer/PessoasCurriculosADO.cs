using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using GWI.Models.Curriculos;
using GWI.Models.Pessoas;
using GWI.Models;

namespace GWI.Repositories.ADO.SQLServer
{
    public class PessoasCurriculosADO
    {
        private readonly string connectionString;
        public PessoasCurriculosADO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        // CRUD Formação e Expêriencias Profissionais //
        #region
        public void CreateForExp(ForExp forExp)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO tb_form_exp (fe_tipo, fe_nome, fe_instituicao, fe_ano_ini, fe_ano_ter, fe_descricao, fe_ar_id, fe_p_id) VALUES (@fe_tipo, @fe_nome, @fe_instituicao, @fe_ano_ini, @fe_ano_ter, @fe_descricao, @fe_ar_id, @fe_p_id); select convert(int, @@identity) as id;";

                    command.Parameters.Add(new SqlParameter("@fe_tipo", System.Data.SqlDbType.Bit)).Value = forExp.fe_tipo;
                    command.Parameters.Add(new SqlParameter("@fe_nome", System.Data.SqlDbType.VarChar)).Value = forExp.fe_nome;
                    command.Parameters.Add(new SqlParameter("@fe_instituicao", System.Data.SqlDbType.VarChar)).Value = forExp.fe_instituicao;
                    command.Parameters.Add(new SqlParameter("@fe_ano_ini", System.Data.SqlDbType.VarChar)).Value = forExp.fe_ano_ini;
                    command.Parameters.Add(new SqlParameter("@fe_ano_ter", System.Data.SqlDbType.VarChar)).Value = forExp.fe_ano_ter;
                    command.Parameters.Add(new SqlParameter("@fe_descricao", System.Data.SqlDbType.VarChar)).Value = forExp.fe_descricao;
                    command.Parameters.Add(new SqlParameter("@fe_ar_id", System.Data.SqlDbType.Int)).Value = forExp.fe_ar_id;
                    command.Parameters.Add(new SqlParameter("@fe_p_id", System.Data.SqlDbType.Int)).Value = forExp.fe_p_id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ForExpArea> GetForExps(int p_id)
        {
            List<ForExpArea> forExpAreas = new List<ForExpArea>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT fe_id, fe_tipo, fe_nome, fe_instituicao, fe_ano_ini, fe_ano_ter, fe_descricao, fe_ar_id, ar_nome, ar_tipo FROM tb_form_exp INNER JOIN tb_pessoas ON tb_form_exp.fe_p_id = tb_pessoas.p_id INNER JOIN tb_areas ON tb_form_exp.fe_ar_id = tb_areas.ar_id WHERE p_id = @p_id;";

                    command.Parameters.Add(new SqlParameter("@p_id", System.Data.SqlDbType.Int)).Value = p_id;

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        ForExpArea forExpArea = new ForExpArea();

                        forExpArea.fe_id = (int)dr["fe_id"];
                        forExpArea.fe_tipo = (bool)dr["fe_tipo"];
                        forExpArea.fe_nome = (string)dr["fe_nome"];
                        forExpArea.fe_instituicao = (string)dr["fe_instituicao"];
                        forExpArea.fe_ano_ini = (int)dr["fe_ano_ini"];
                        forExpArea.fe_ano_ter = (int)dr["fe_ano_ter"];
                        forExpArea.fe_descricao = (string)dr["fe_descricao"];
                        forExpArea.ar_nome = (string)dr["ar_nome"];
                        forExpArea.ar_tipo = (string)dr["ar_tipo"];

                        forExpAreas.Add(forExpArea);
                    }
                }
            }

            return forExpAreas;
        }

        public ForExpArea GetByIdForExp(int fe_id)
        {
            ForExpArea forExpArea = new ForExpArea();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT fe_id, fe_tipo, fe_nome, fe_instituicao, fe_ano_ini, fe_ano_ter, fe_descricao, fe_ar_id, ar_id, ar_nome, ar_tipo FROM tb_form_exp INNER JOIN tb_pessoas ON tb_form_exp.fe_p_id = tb_pessoas.p_id INNER JOIN tb_areas ON tb_form_exp.fe_ar_id = tb_areas.ar_id WHERE fe_id = @fe_id;";

                    command.Parameters.Add(new SqlParameter("@fe_id", System.Data.SqlDbType.Int)).Value = fe_id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        forExpArea.fe_id = (int)dr["fe_id"];
                        forExpArea.fe_tipo = (bool)dr["fe_tipo"];
                        forExpArea.fe_nome = (string)dr["fe_nome"];
                        forExpArea.fe_instituicao = (string)dr["fe_instituicao"];
                        forExpArea.fe_ano_ini = (int)dr["fe_ano_ini"];
                        forExpArea.fe_ano_ter = (int)dr["fe_ano_ter"];
                        forExpArea.fe_descricao = (string)dr["fe_descricao"];
                        forExpArea.ar_id = (int)dr["ar_id"];
                        forExpArea.ar_nome = (string)dr["ar_nome"];
                        forExpArea.ar_tipo = (string)dr["ar_tipo"];
                    }
                }
            }

            return forExpArea;
        }

        public void UpdateForExp(ForExpArea forExp)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE tb_form_exp SET fe_tipo = @fe_tipo, fe_nome = @fe_nome, fe_instituicao = @fe_instituicao, fe_ano_ini = @fe_ano_ini, fe_ano_ter = @fe_ano_ter, fe_descricao = @fe_descricao, fe_ar_id = @fe_ar_id WHERE fe_id = @fe_id;; select convert(int, @@identity) as id;";

                    command.Parameters.Add(new SqlParameter("@fe_id", System.Data.SqlDbType.Int)).Value = forExp.fe_id;
                    command.Parameters.Add(new SqlParameter("@fe_tipo", System.Data.SqlDbType.Bit)).Value = forExp.fe_tipo;
                    command.Parameters.Add(new SqlParameter("@fe_nome", System.Data.SqlDbType.VarChar)).Value = forExp.fe_nome;
                    command.Parameters.Add(new SqlParameter("@fe_instituicao", System.Data.SqlDbType.VarChar)).Value = forExp.fe_instituicao;
                    command.Parameters.Add(new SqlParameter("@fe_ano_ini", System.Data.SqlDbType.Int)).Value = forExp.fe_ano_ini;
                    command.Parameters.Add(new SqlParameter("@fe_ano_ter", System.Data.SqlDbType.Int)).Value = forExp.fe_ano_ter;
                    command.Parameters.Add(new SqlParameter("@fe_descricao", System.Data.SqlDbType.VarChar)).Value = forExp.fe_descricao;
                    command.Parameters.Add(new SqlParameter("@fe_ar_id", System.Data.SqlDbType.Int)).Value = forExp.fe_ar_id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DefDelete(int fe_id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM tb_form_exp WHERE fe_id = @fe_id;";

                    command.Parameters.Add(new SqlParameter("@fe_id", System.Data.SqlDbType.Int)).Value = fe_id;

                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        // Áreas //
        #region
        public List<Areas> GetAreas()
        {
            List<Areas> areas = new List<Areas>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT ar_id, ar_tipo, ar_nome FROM tb_areas;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Areas area = new Areas();
                        area.ar_id = (int)dr["ar_id"];
                        area.ar_tipo = (string)dr["ar_tipo"];
                        area.ar_nome = (string)dr["ar_nome"];

                        areas.Add(area);
                    }
                }
            }

            return areas;
        }
        #endregion

        // CNH //
        #region
        public List<Cnh> GetCnhs()
        {
            List<Cnh> cnhs = new List<Cnh>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT cnh_id, cnh_tipo FROM tb_cnh;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Cnh cnh = new Cnh();
                        cnh.cnh_id = (int)dr["cnh_id"];
                        cnh.cnh_tipo = (string)dr["cnh_tipo"];

                        cnhs.Add(cnh);
                    }
                }
            }

            return cnhs;
        }
        #endregion

        // Habilidades //
        #region
        public List<Habilidades> GetHabilidades()
        {
            List<Habilidades> habilidades = new List<Habilidades>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT hb_id, hb_tipo, hb_nome FROM tb_habilidades;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Habilidades habilidade = new Habilidades();
                        habilidade.hb_id = (int)dr["hb_id"];
                        habilidade.hb_tipo = (string)dr["hb_tipo"];
                        habilidade.hb_nome = (string)dr["hb_nome"];

                        habilidades.Add(habilidade);
                    }
                }
            }

            return habilidades;
        }
        #endregion

        // Pessoas //
        #region

        public Pessoas GetByIdPessoa(int id)
        {
            Pessoas pessoa = new Pessoas();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT p_id, p_userName, p_nome, p_sobrenome, p_email, p_telefone FROM tb_pessoas WHERE p_id = @p_id;";
                    command.Parameters.Add(new SqlParameter("@p_id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        pessoa.p_id = (int)dr["p_id"];
                        pessoa.p_username = (string)dr["p_username"];
                        pessoa.p_nome = (string)dr["p_nome"];
                        pessoa.p_sobrenome = (string)dr["p_sobrenome"];
                        pessoa.p_email = (string)dr["p_email"];
                        pessoa.p_telefone = (string)dr["p_telefone"];
                    }
                }
            }

            return pessoa;
        }

        #endregion

        // Curriculo Completo //
        #region
        public void CreateCurriculo(CurriculoCompleto cr)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT into tb_pessoas_curriculos (cr_objetivos, cr_endereco, cr_p_id) values (@cr_objetivos, @cr_endereco, @cr_p_id); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@cr_objetivos", System.Data.SqlDbType.VarChar)).Value = cr.Objetivos;
                    command.Parameters.Add(new SqlParameter("@cr_endereco", System.Data.SqlDbType.VarChar)).Value = cr.Endereco;
                    command.Parameters.Add(new SqlParameter("@cr_p_id", System.Data.SqlDbType.Int)).Value = cr.P_Id;

                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand())
                {
                    foreach (int item in cr.Habilidade)
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO tb_hbcr (hbcr_cr_id, hbcr_hb_id) VALUES ((SELECT TOP (1) cr_id FROM tb_pessoas_curriculos ORDER BY cr_id DESC), @hbcr_hb_id);";

                        command.Parameters.Clear();

                        command.Parameters.Add(new SqlParameter("@hbcr_hb_id", System.Data.SqlDbType.Int)).Value = item;

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public CurriculoCompleto GetCurriculo()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                CurriculoCompleto cr = new CurriculoCompleto();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT cr_endereco, cr_objetivos, p_nome, p_sobrenome, p_telefone, p_email FROM tb_pessoas_curriculos INNER JOIN tb_pessoas ON cr_p_id = p_id;";

                    SqlDataReader dr = command.ExecuteReader();
              
                    cr.Endereco = (string)dr["cr_endereco"];
                    cr.Objetivos = (string)dr["cr_objetivos"];
                    cr.Nome = (string)dr["p_nome"];
                    cr.Sobrenome = (string)dr["p_sobrenome"];
                    cr.Telefone = (string)dr["p_telefone"];
                    cr.Email = (string)dr["p_email"];
                    
                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT cnh_tipo FROM tb_pessoas_curriculos INNER JOIN tb_cnhcr ON hbtcr_cr_id = cr_id INNER JOIN tb_cnh ON cnh_id = cnhcr_hbt_id;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {                        
                        cr.Cnhs.Add((string)dr["cnh_tipo"]);
                    }
                }

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT hb_nome FROM tb_pessoas_curriculos INNER JOIN tb_hbcr ON hbcr_cr_id = cr_id INNER JOIN tb_habilidades ON hb_id = hbcr_hb_id;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        cr.Hab.Add((string)dr["hb_nome"]);
                    }
                }

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT fe_nome, fe_instituicao, fe_ano_ini, fe_ano_ter, fe_descricao, fe_tipo FROM tb_pessoas_curriculos INNER JOIN tb_fecr ON fecr_cr_id = cr_id INNER JOIN tb_form_exp ON fecr_fe_id = fe_id;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        ForExp hb = new ForExp();
                        hb.fe_nome = (string)dr["fe_nome"];
                        hb.fe_instituicao = (string)dr["fe_instituicao"];
                        hb.fe_ano_ini = (int)dr["fe_ano_ini"];
                        hb.fe_ano_ter = (int)dr["fe_ano_ter"];
                        hb.fe_descricao = (string)dr["fe_descricao"];
                        hb.fe_tipo = (bool)dr["fe_tipo"];

                        cr.Fe.Add(hb);
                    }                    
                }

                return cr;
            }
        }
        #endregion
    }
}
