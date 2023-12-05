﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using GWI.Models.Curriculos;
using GWI.Models.Pessoas;

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
                    command.CommandText = "INSERT INTO tb_form_exp (fe_tipo, fe_nome, fe_instituicao, fe_ano_ini, fe_ano_ter, fe_descricao, fe_ar_id) VALUES (@fe_tipo, @fe_nome, @fe_instituicao, @fe_ano_ini, @fe_ano_ter, @fe_descricao, @fe_ar_id); select convert(int, @@identity) as id;";

                    command.Parameters.Add(new SqlParameter("@fe_tipo", System.Data.SqlDbType.Bit)).Value = forExp.fe_tipo;
                    command.Parameters.Add(new SqlParameter("@fe_nome", System.Data.SqlDbType.VarChar)).Value = forExp.fe_nome;
                    command.Parameters.Add(new SqlParameter("@fe_instituicao", System.Data.SqlDbType.VarChar)).Value = forExp.fe_instituicao;
                    command.Parameters.Add(new SqlParameter("@fe_ano_ini", System.Data.SqlDbType.VarChar)).Value = forExp.fe_ano_ini;
                    command.Parameters.Add(new SqlParameter("@fe_ano_ter", System.Data.SqlDbType.VarChar)).Value = forExp.fe_ano_ter;
                    command.Parameters.Add(new SqlParameter("@fe_descricao", System.Data.SqlDbType.VarChar)).Value = forExp.fe_descricao;
                    command.Parameters.Add(new SqlParameter("@fe_ar_id", System.Data.SqlDbType.Int)).Value = forExp.fe_ar_id;

                    forExp.fe_id = (int)command.ExecuteScalar();
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
                        forExpArea.fe_ano_ini = (DateTime)dr["fe_ano_ini"];
                        forExpArea.fe_ano_ter = (DateTime)dr["fe_ano_ter"];
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
                    command.CommandText = "SELECT fe_id, fe_tipo, fe_nome, fe_instituicao, fe_ano_ini, fe_ano_ter, fe_descricao, fe_ar_id, ar_nome, ar_tipo FROM tb_form_exp INNER JOIN tb_pessoas ON tb_form_exp.fe_p_id = tb_pessoas.p_id INNER JOIN tb_areas ON tb_form_exp.fe_ar_id = tb_areas.ar_id WHERE fe_id = @fe_id;";

                    command.Parameters.Add(new SqlParameter("@fe_id", System.Data.SqlDbType.Int)).Value = fe_id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        forExpArea.fe_id = (int)dr["fe_id"];
                        forExpArea.fe_tipo = (bool)dr["fe_tipo"];
                        forExpArea.fe_nome = (string)dr["fe_nome"];
                        forExpArea.fe_instituicao = (string)dr["fe_instituicao"];
                        forExpArea.fe_ano_ini = (DateTime)dr["fe_ano_ini"];
                        forExpArea.fe_ano_ter = (DateTime)dr["fe_ano_ter"];
                        forExpArea.fe_descricao = (string)dr["fe_descricao"];
                        forExpArea.ar_nome = (string)dr["ar_nome"];
                        forExpArea.ar_tipo = (string)dr["ar_tipo"];
                    }
                }
            }

            return forExpArea;
        }

        public void UpdateForExp(int fe_id, ForExp forExp)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE tb_form_exp SET fe_tipo = @fe_tipo, fe_nome = @fe_nome, fe_instituicao = @fe_instituicao, fe_ano_ini = @fe_ano_ini, fe_ano_ter = @fe_ano_ter, fe_descricao = @fe_descricao, fe_ar_id = 50 WHERE fe_id = @fe_id;; select convert(int, @@identity) as id;";

                    command.Parameters.Add(new SqlParameter("@fe_id", System.Data.SqlDbType.Bit)).Value = forExp.fe_id;
                    command.Parameters.Add(new SqlParameter("@fe_tipo", System.Data.SqlDbType.Bit)).Value = forExp.fe_tipo;
                    command.Parameters.Add(new SqlParameter("@fe_nome", System.Data.SqlDbType.VarChar)).Value = forExp.fe_nome;
                    command.Parameters.Add(new SqlParameter("@fe_instituicao", System.Data.SqlDbType.VarChar)).Value = forExp.fe_instituicao;
                    command.Parameters.Add(new SqlParameter("@fe_ano_ini", System.Data.SqlDbType.VarChar)).Value = forExp.fe_ano_ini;
                    command.Parameters.Add(new SqlParameter("@fe_ano_ter", System.Data.SqlDbType.VarChar)).Value = forExp.fe_ano_ter;
                    command.Parameters.Add(new SqlParameter("@fe_descricao", System.Data.SqlDbType.VarChar)).Value = forExp.fe_descricao;
                    command.Parameters.Add(new SqlParameter("@fe_ar_id", System.Data.SqlDbType.Int)).Value = forExp.fe_ar_id;

                    forExp.fe_id = (int)command.ExecuteScalar();
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


        // CRUD CNH //
        #region

        #endregion


        // CRUD Habilidades //
        #region

        #endregion
    }
}