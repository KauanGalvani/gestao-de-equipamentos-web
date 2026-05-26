using GestaoDeEquipamentosWeb.ConsoleApp.ModuloChamado;

namespace GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado;

public interface IRepositorio<T> where T : EntidadeBase<T>
{
    void Cadastrar(T entidade);
    bool Editar(string idSelecionado, T entidadeAtualizada);
    bool Excluir(T registro);
    List<Chamado> Filtrar(Predicate<Chamado> filtro);
    T? SelecionarPorId(string idSelecionado);
    List<T> SelecionarTodos();
}
