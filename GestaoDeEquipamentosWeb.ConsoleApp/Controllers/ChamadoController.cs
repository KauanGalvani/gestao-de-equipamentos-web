using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado;
using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado.Arquivos;
using GestaoDeEquipamentosWeb.ConsoleApp.Models;
using GestaoDeEquipamentosWeb.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentosWeb.ConsoleApp.ModuloEquipamento;
using Microsoft.AspNetCore.Mvc;

public class ChamadoController : Controller
{
    private readonly IRepositorio<Chamado> repositorioChamado;
    private readonly IRepositorio<Equipamento> repositorioEquipamento;

    public ChamadoController(IRepositorio<Chamado> repositorioChamado, IRepositorio<Equipamento> repositorioEquipamento)
    {
        this.repositorioChamado = repositorioChamado;
        this.repositorioEquipamento = repositorioEquipamento;
    }

    public ChamadoController()
    {
        ContextoJson contexto = new ContextoJson();
        contexto.Carregar();

        repositorioChamado = new RepositorioChamadoEmArquivo(contexto);
        repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);

    }

    [HttpGet]

    public ActionResult Listar()
    {
        List<Chamado> chamados = repositorioChamado.SelecionarTodos();

        List<ListarChamadoVireModel> visualizarChamado = new List<ListarChamadoVireModel>();

        foreach (Chamado c in chamados)
        {
            ListarChamadoVireModel listarChamado = new ListarChamadoVireModel(
                c.Id,
                c.Titulo,
                c.Equipamento.Nome,
                c.DataAbertura,
                c.TempoDecorrido,
                c.EstaConcluido
            );

            visualizarChamado.Add(listarChamado);
        }
        return View(visualizarChamado);
    }
}