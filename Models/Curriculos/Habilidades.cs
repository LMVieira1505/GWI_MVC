namespace GWI.Models.Curriculos
{
    public class Habilidades
    {

        public int hb_id { get; set; }
        public string hb_tipo { get; set; }
        public string hb_nome { get; set; }

        public Habilidades()
        {
            hb_id = 0;
            hb_tipo = string.Empty;
            hb_nome = string.Empty;
        }
    }
}