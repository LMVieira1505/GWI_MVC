namespace GWI.Models
{
    public class CurriculoCompleto
    {
        public int Id { get; set; }
        public int P_Id { get; set; }
        public List<int> Cnh { get; set; }
        public List<int> Habilidade { get; set; }
        public List<int> Forexp { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Imagem { get; set; }
        public string Objetivos { get; set; }
        public string Endereco {  get; set; }
    }
}
