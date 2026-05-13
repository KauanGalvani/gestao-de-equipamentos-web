using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado;
using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado.Arquivos;

namespace GestaoDeEquipamentosWeb.ConsoleApp.ModuloChamado;

public class RepositorioChamadoEmArquivo : RepositorioBaseEmArquivo<Chamado>, IRepositorio<Chamado>
{
    public RepositorioChamadoEmArquivo(ContextoJson contexto) : base(contexto) { }

    protected override List<Chamado> CarregarRegistros()
    {
        return contexto.Chamados;
    }
}
