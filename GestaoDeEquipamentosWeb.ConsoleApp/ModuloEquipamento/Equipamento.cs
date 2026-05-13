using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado;
using GestaoDeEquipamentosWeb.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentosWeb.ConsoleApp.ModuloEquipamento;

public class Equipamento : EntidadeBase<Equipamento>
{
    public string Nome { get; set; } = string.Empty;
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }
    public Fabricante Fabricante { get; set; } = null!;

    public Equipamento() { }

    public Equipamento(
        string nome,
        decimal precoAquisicao,
        DateTime dataFabricacao,
        Fabricante fabricante
    ) : this()
    {
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        Fabricante = fabricante;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 2 || Nome.Length > 50)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 50 caracteres.");

        if (PrecoAquisicao <= 0)
            erros.Add("O campo \"Preço de Aquisição\" deve conter um valor positivo.");

        if (DataFabricacao > DateTime.Now)
            erros.Add("O campo \"Data de Fabricação\" deve conter uma data do passado.");

        if (Fabricante == null)
            erros.Add("O campo \"Fabricante\" deve ser preenchido.");

        return erros;
    }

    public override void AtualizarDados(Equipamento entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        PrecoAquisicao = entidadeAtualizada.PrecoAquisicao;
        DataFabricacao = entidadeAtualizada.DataFabricacao;
        Fabricante = entidadeAtualizada.Fabricante;
    }
}
