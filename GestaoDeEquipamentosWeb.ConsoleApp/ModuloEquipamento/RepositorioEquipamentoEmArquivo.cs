using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado;
using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado.Arquivos;

namespace GestaoDeEquipamentosWeb.ConsoleApp.ModuloEquipamento;

public class RepositorioEquipamentoEmArquivo :
    RepositorioBaseEmArquivo<Equipamento>, IRepositorio<Equipamento>
{
    public RepositorioEquipamentoEmArquivo(ContextoJson contexto) : base(contexto) { }

    protected override List<Equipamento> CarregarRegistros()
    {
        return contexto.Equipamentos;
    }
}
