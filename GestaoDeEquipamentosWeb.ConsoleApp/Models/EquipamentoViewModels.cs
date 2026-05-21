using GestaoDeEquipamentosWeb.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentosWeb.ConsoleApp.Models;

public record ListarEquipamentosViewModel(
    string Id,
    string Nome,
    decimal PrecoAquisicao,
    DateTime DataFabricacao,
    string Fabricante
);

public record CadastrarEquipamentoViewModel(
    string Nome,
    decimal PrecoAquisicao,
    DateTime DataFabricacao,
    string FabricanteId
);

public record EditarEquipamentoViewModel(
    string Id,
    string Nome,
    decimal PrecoAquisicao,
    DateTime DataFabricacao,
    string FabricanteId
);

public record ExcluirEquipamentoViewModel(
    string Id,
    string Nome,
    decimal PrecoAquisicao,
    DateTime DataFabricacao,
    string Fabricante
);