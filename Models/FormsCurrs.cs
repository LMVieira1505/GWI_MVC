namespace GWI.Models
{
    public class FormsCurrs
    {
        public class FormCurriculo
        {
            private int Id { get; set; }
            private int Id_usuario { get; set; }
            private string Nome_usuario { get; set; }
            private string Telefone_usuario { get; set; }
            private string Email_usuario { get; set; }
            private string Endereco { get; set; }
            private DateTime DataNas { get; set; }
            private string EstadoCivil { get; set; }
            private List<string> Habilitacao { get; set; }
            private List<string> Objetivos { get; set; }
            private List<string> ExpProf { get; set; }
            private List<string> FormAcad { get; set; }
            private List<string> Habilidades { get; set; }
            private string Foto { get; set; }
        }

    }
}
