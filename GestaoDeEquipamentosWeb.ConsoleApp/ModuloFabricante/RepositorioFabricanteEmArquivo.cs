using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado;
using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado.Arquivos;

namespace GestaoDeEquipamentosWeb.ConsoleApp.ModuloFabricante;

public class RepositorioFabricanteEmArquivo :
    RepositorioBaseEmArquivo<Fabricante>, IRepositorio<Fabricante>
{
    public RepositorioFabricanteEmArquivo(ContextoJson contexto) : base(contexto) { }

    protected override List<Fabricante> CarregarRegistros()
    {
        return contexto.Fabricantes;
    }
}
