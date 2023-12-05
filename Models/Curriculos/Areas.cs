namespace GWI.Models.Curriculos
{
    public class Areas
    {
        public int ar_id { get; set; }
        public string ar_tipo { get; set; }
        public string ar_nome { get; set;}

        public Areas()
        {
            ar_id = 0;
            ar_tipo = string.Empty;
            ar_nome = string.Empty;
        }
    }
}
