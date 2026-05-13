using System;
using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado;
using GestaoDeEquipamentosWeb.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentosWeb.ConsoleApp.ModuloChamado;

public class Chamado : EntidadeBase<Chamado>
{
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; } = null;
    public Equipamento Equipamento { get; set; } = null!;
    public DateTime DataAbertura { get; set; } = DateTime.Now;
    public bool EstaConcluido { get; set; }
    public int TempoDecorrido
    {
        get
        {
            TimeSpan diferencaTempo = DateTime.Now.Subtract(DataAbertura);

            return diferencaTempo.Days;
        }
    }

    public Chamado() { }

    public Chamado(string titulo, Equipamento equipamento, string? descricao = null) : this()
    {
        Titulo = titulo;
        Equipamento = equipamento;
        Descricao = descricao;
    }

    public void Concluir()
    {
        EstaConcluido = true;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Titulo) || Titulo.Length < 2 || Titulo.Length > 50)
            erros.Add("O campo \"Título\" deve conter entre 2 e 50 caracteres.");

        if (Equipamento == null)
            erros.Add("O campo \"Equipamento\" deve ser preenchido.");

        return erros;
    }

    public override void AtualizarDados(Chamado entidadeAtualizada)
    {
        Titulo = entidadeAtualizada.Titulo;
        Descricao = entidadeAtualizada.Descricao;
        Equipamento = entidadeAtualizada.Equipamento;
    }
}
