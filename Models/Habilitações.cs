namespace GWI.Models
{
    public class Habilitações
    { 
        public int hbt_id { get; set; }
        public string hbt_letra { get; set; }

        public Habilitações() 
        {
            hbt_id = 0;
            hbt_letra = string.Empty;
        }   
    }
}

