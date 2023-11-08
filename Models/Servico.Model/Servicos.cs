namespace GWI.Models.Servico.Model
{
    public class Servicos
    {
        public class Servico
        {
            private string Titulo { get; set; }
            private string Subtitulo { get; set; }
            private int Autor_Id_pess { get; set; }
            private string Texto { get; set; }
            private List<int> Id_img { get; set; }

            private bool Ativo;
            private DateTime Data_Pub { get; set; }
        }
    }
}

