using Newtonsoft.Json;
using GWI.Models.Pessoas;

namespace GWI.Services
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string tokenSessao;


        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.tokenSessao = "pessoas";
        }

        public void addTokenPessoas(Pessoas pessoas)
        {
            string pessoasTokenJson = JsonConvert.SerializeObject(pessoas);
            this.httpContextAccessor.HttpContext?.Session.SetString(this.tokenSessao, pessoasTokenJson);
        }

        public Pessoas getTokenPessoas()
        {
            string? pessoasTokenJson = this.httpContextAccessor.HttpContext?.Session.GetString(this.tokenSessao);
            return pessoasTokenJson != null ? JsonConvert.DeserializeObject<Pessoas>(pessoasTokenJson) : null;
        }

        public void deleteTokenPessoas()
        {
            this.httpContextAccessor.HttpContext?.Session.Remove(this.tokenSessao);
        }
    }
}
