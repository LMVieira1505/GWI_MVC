namespace GWI.Models.Noticias
{
    public class NoticiaImagemAutor
    {
        public int nt_id { get; set; }
        public string nt_titulo { get; set; }
        public string nt_subtitulo { get; set; }
        public string nt_texto { get; set; }
        public DateTime nt_data_publicacao { get; set; }
        public string p_username { get; set; }
        public bool imn_capa { get; set; }
        public string im_url { get; set; }

        public NoticiaImagemAutor()
        {
            nt_id = 0;
            nt_titulo = string.Empty;
            nt_subtitulo = string.Empty;
            nt_texto = string.Empty;
            nt_data_publicacao = DateTime.Now;
            p_username = string.Empty;
            imn_capa = true;
            im_url = string.Empty;
        }
    }
}