namespace GWI.Models.Curriculos
{
    public class Cnh
    {
        public int cnh_id { get; set; }
        public string cnh_tipo { get; set; }

        public Cnh()
        {
            cnh_id = 0;
            cnh_tipo = string.Empty;
        }
    }
}