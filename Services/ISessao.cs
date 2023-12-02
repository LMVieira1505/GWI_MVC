using GWI.Models.Pessoas;
using GWI.Models.Pessoas.Pessoas;
using GWI.Models.Pessoas.Pessoas.Pessoas;
using GWI.Models.Pessoas.Pessoas.Pessoas.Pessoas;
using GWI.Models.Pessoas.Pessoas.Pessoas.Pessoas.Pessoas;
using GWI.Models.Pessoas.Pessoas.Pessoas.Pessoas.Pessoas.Pessoas;
using GWI.Models.Pessoas.Pessoas.Pessoas.Pessoas.Pessoas.Pessoas.Pessoas;

namespace GWI.Services
{
    public interface ISessao
    {
        void addTokenPessoas(Pessoas pessoa);

        Pessoas getTokenPessoas();

        void deleteTokenPessoas();
    }
}

