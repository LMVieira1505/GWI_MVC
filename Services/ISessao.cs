using GWI.Models.Pessoas;

namespace GWI.Services
{
    public interface ISessao
    {
        void addTokenPessoas(Pessoas pessoa);

        Pessoas getTokenPessoas();

        void deleteTokenPessoas();
    }
}

