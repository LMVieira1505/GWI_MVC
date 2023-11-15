using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWI.Models
{
    public class Imagens
    {
        public int im_id { get; set; }
        public string im_url { get; set; }
        public Imagens()
        {
            im_id = 0;
            im_url = string.Empty;
        }
    }
}
