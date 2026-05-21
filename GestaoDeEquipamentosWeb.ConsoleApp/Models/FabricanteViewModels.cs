namespace GestaoDeEquipamentosWeb.ConsoleApp.Models;

public record ListarFabricantesViewModel(
    string Id,
    string Nome,
    string Email,
    string Telefone
);

public record CadastrarFabricanteViewModel(
    string Nome,
    string Email,
    string Telefone
);

public record EditarFabricanteViewModel(
    string Id,
    string Nome,
    string Email,
    string Telefone
);

public record ExcluirFabricanteViewModel(
    string Id,
    string Nome,
    string Email,
    string Telefone
);