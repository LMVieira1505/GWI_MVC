namespace GWI.Models
{
    public class Imagens
    {
        public abstract class Imagem
        {

            private int Id_img { get; set; }
            private string URL { get; set; }

            public class Img_Propag : Imagem
            {

            }

            public class Img_serviços : Imagem
            {
                private int Id_servico { get; set; }
            }

            public class Img_Not : Imagem
            {
                private int Id_noticia { get; set; }
            }
        }
    }
}
