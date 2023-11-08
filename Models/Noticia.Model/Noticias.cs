﻿namespace GWI.Models.Noticia.Model
{
    public class Noticias
    {
        public class Noticia
        {
            private int Id_not { get; set; }
            private int Id_categoria { get; set; }
            private List<int> Id_subcategoria { get; set; }
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
