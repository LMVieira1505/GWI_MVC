namespace GWI.Models
{
    public class NoticiaImagemAutor
    {
        public int nt_id { get; set; }
        public string nt_titulo { get; set;}
        public string nt_subtitulo { get; set; }
        public string nt_texto { get; set; }
        public DateTime nt_data_publicacao { get; set; }
        public string p_username { get; set; }
        public bool imn_capa { get; set; }
        public string im_url { get; set;}
    }
}