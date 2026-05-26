using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado;
using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado.Arquivos;
using GestaoDeEquipamentosWeb.ConsoleApp.Models;
using GestaoDeEquipamentosWeb.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentosWeb.ConsoleApp.ModuloEquipamento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ChamadoController : Controller
{
    private readonly IRepositorioChamado repositorioChamado;
    private readonly IRepositorio<Equipamento> repositorioEquipamento;

    public ChamadoController()
    {
        ContextoJson contexto = new ContextoJson();
        contexto.Carregar();

        repositorioChamado = new RepositorioChamadoEmArquivo(contexto);
        repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);

    }

    [HttpGet]
    public ActionResult Listar(string? status)
    {
        string? statusSelecionado = status?.ToLower();

        List<Chamado> chamados;

        if (statusSelecionado == "em-aberto") // metodo anonimo
            chamados = repositorioChamado.Filtrar(chamado => !chamado.EstaConcluido);

        else if (statusSelecionado == "concluidos")
            chamados = repositorioChamado.Filtrar(chamado => chamado.EstaConcluido);
        else
            chamados = repositorioChamado.SelecionarTodos();

        List<ListarChamadoViewModel> visualizarChamado = new List<ListarChamadoViewModel>();

        foreach (Chamado c in chamados)
        {
            ListarChamadoViewModel listarChamadoVm = new ListarChamadoViewModel(
                c.Id,
                c.Titulo,
                c.Equipamento.Nome,
                c.DataAbertura,
                c.TempoDecorrido,
                c.EstaConcluido
            );

            visualizarChamado.Add(listarChamadoVm);
        }

        ViewBag.statusSekecionado = statusSelecionado;

        return View(visualizarChamado);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        ViewBag.Equipamento = CarregarEquipamentos();

        new CadastrarChamadoViewModel(string.Empty, null, string.Empty);

        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarChamadoViewModel cadastrarVm)
    {
        Equipamento? equipamento = repositorioEquipamento.SelecionarPorId(cadastrarVm.EquipamentoId);

        if (equipamento == null)
        {
            ModelState.AddModelError(nameof(cadastrarVm.EquipamentoId), "Selecione um equipamento valido.");
        }
        if (!ModelState.IsValid)
        {
            return View(cadastrarVm);
        }

        Chamado novoChamado = new Chamado(
            cadastrarVm.Titulo,
            equipamento,
            cadastrarVm.Descricao
        );
        repositorioChamado.Cadastrar(novoChamado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]

    public ActionResult Editar(string id)
    {
        Chamado? chamado = repositorioChamado.SelecionarPorId(id);

        if (chamado == null)
            return RedirectToAction(nameof(Listar));

        EditarChamadoViewModel editarChamadoVm = new EditarChamadoViewModel(
            chamado.Id,
            chamado.Titulo,
            chamado.Descricao,
            chamado.Equipamento.Id,
            chamado.EstaConcluido
        );

        ViewBag.Equipamento = CarregarEquipamentos();

        return View(editarChamadoVm);
    }

    [HttpPost]

    public ActionResult Editar(EditarChamadoViewModel editarVm)
    {
        Equipamento? equipamento = repositorioEquipamento.SelecionarPorId(editarVm.EquipamentoId);

        if (equipamento == null)
        {
            ModelState.AddModelError(nameof(editarVm.EquipamentoId), "Selecione um equipamento valido.");
        }
        if (!ModelState.IsValid)
        {
            return View(editarVm);
        }

        Chamado novoChamado = new Chamado(
            editarVm.Titulo,
            equipamento!,
            editarVm.EstaConcluido,
            editarVm.Descricao
        );

        repositorioChamado.Editar(editarVm.Id, novoChamado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Chamado? chamado = repositorioChamado.SelecionarPorId(id);

        if (chamado == null)
            return RedirectToAction(nameof(Listar));

        ExcluirChamadoViewModel excluirVm = new ExcluirChamadoViewModel(
            chamado.Id,
            chamado.Titulo,
            chamado.Descricao,
            chamado.Equipamento.Nome,
            chamado.DataAbertura,
            chamado.TempoDecorrido,
            chamado.EstaConcluido
        );


        return View(excluirVm);
    }

    [HttpPost]
    [ActionName("Excluir")]

    public ActionResult ExcluirConfirmado(ExcluirChamadoViewModel excluirVm)
    {
        Chamado? chamado = repositorioChamado.SelecionarPorId(excluirVm.Id);

        if (chamado != null)
            repositorioChamado.Excluir(chamado);

        return RedirectToAction(nameof(Listar));
    }

    private List<SelectListItem> CarregarEquipamentos()
    {
        List<Equipamento> equipamentos = repositorioEquipamento.SelecionarTodos();

        List<SelectListItem> selecionarEquipamento = new List<SelectListItem>();

        foreach (Equipamento e in equipamentos)
        {
            SelectListItem selecionarEquipamentosVm = new SelectListItem(
                e.Nome,
                e.Id
            );

            selecionarEquipamento.Add(selecionarEquipamentosVm);
        }

        return selecionarEquipamento;
    }
}