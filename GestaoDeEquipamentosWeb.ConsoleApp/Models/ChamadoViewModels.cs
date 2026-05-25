namespace GestaoDeEquipamentosWeb.ConsoleApp.Models;

public record ListarChamadoVireModel(
    string Id,
    string Titulo,
    string Equipamento,
    DateTime DataAbertura,
    int TempoDecorrido,
    bool EstaConcluido
);