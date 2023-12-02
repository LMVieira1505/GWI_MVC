using Microsoft.Data.SqlClient;
using GWI.Models.Imagens;

namespace GWI.Repositories.ADO.SQLServer
{
    public class ImgNotADO
    {
        private readonly string connectionString;
        public ImgNotADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void add(ImgNot imagensnot)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into tb_img_not (imn_id, imn_im_id, imn_nt_id, imn_capa ) values (@imn_id, @imn_im_id, @imn_nt_id, @imn_capa); select convert(int,@@identity) as imn_id;;";

                    command.Parameters.Add(new SqlParameter("@imn_im_id", System.Data.SqlDbType.VarChar)).Value = imagensnot.imn_im_id;
                    command.Parameters.Add(new SqlParameter("@imn_nt_id", System.Data.SqlDbType.VarChar)).Value = imagensnot.imn_nt_id;
                    command.Parameters.Add(new SqlParameter("@imn_capa", System.Data.SqlDbType.VarChar)).Value = imagensnot.imn_capa;

                    imagensnot.imn_id = (int)command.ExecuteScalar();
                }
            }
        }

        public List<ImgNot> get()
        {
            List<ImgNot> imagemnot = new List<ImgNot>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select imn_id, imn_im_id, imn_nt_id, imn_capa from tb_img_not;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        ImgNot imagensnot = new ImgNot();
                        imagensnot.imn_id = (int)dr["imn_id"];
                        imagensnot.imn_im_id = (int)dr["imn_im_id"];
                        imagensnot.imn_nt_id = (int)dr["imn_nt_id"];
                        imagensnot.imn_capa = (string)dr["imn_capa"];

                        imagemnot.Add(imagensnot);
                    }
                }
            }

            return imagemnot;
        }

        public void delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "delete from tb_img_not where imn_id = @imn_id;";
                    command.Parameters.Add(new SqlParameter("@imn_id", System.Data.SqlDbType.Int)).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public ImgNot getById(int id)
        {
            ImgNot imagensnot = new ImgNot();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select imn_id, imn_im_id, imn_nt_id, imn_capa from tb_img_not where imn_id=@imn_id;";
                    command.Parameters.Add(new SqlParameter("@imn_id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        imagensnot.imn_id = (int)dr["imn_id"];
                        imagensnot.imn_im_id = (int)dr["imn_im_id"];
                        imagensnot.imn_nt_id = (int)dr["imn_nt_id"];
                        imagensnot.imn_capa = (string)dr["imn_capa"];

                    }
                }
            }

            return imagensnot;
        }

        public void update(int id, ImgNot imagensnot)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update tb_img_not set imn_im_id = @imn_im_id  where imn_id=@imn_id;";

                    command.Parameters.Add(new SqlParameter("@imn_im_id", System.Data.SqlDbType.VarChar)).Value = imagensnot.imn_im_id;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}