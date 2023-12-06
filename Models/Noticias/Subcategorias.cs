using System.ComponentModel.DataAnnotations;

namespace GWI.Models.Noticias
{
    public class Subcategorias
    {
        public int sct_id { get; set; }
        public string sct_nome { get; set; }
        public bool sct_ativo { get; set; }
        public int sct_cat_id { get; set; }

        public Subcategorias()
        {
            sct_id = 0;
            sct_nome = string.Empty;
            sct_ativo = false;
            sct_cat_id = 0;
        }
    }
}
