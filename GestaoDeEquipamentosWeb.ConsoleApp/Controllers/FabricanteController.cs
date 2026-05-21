using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado;
using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado.Arquivos;
using GestaoDeEquipamentosWeb.ConsoleApp.Models;
using GestaoDeEquipamentosWeb.ConsoleApp.ModuloFabricante;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentosWeb.ConsoleApp.Controllers
{
    public class FabricanteController : Controller
    {
        private IRepositorio<Fabricante> repositorioFabricante;
        public FabricanteController()
        {
            ContextoJson contexto = new ContextoJson();
            contexto.Carregar();

            repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);
        }

        // GET: FabricanteController
        [HttpGet]
        public ActionResult Listar()
        {
            List<Fabricante> fabricantes = repositorioFabricante.SelecionarTodos();

            List<ListarFabricantesViewModel> listaVms = new List<ListarFabricantesViewModel>();

            foreach (Fabricante f in fabricantes)
            {
                //mapear objeto por objeto para viewModels
                ListarFabricantesViewModel viewModel = new ListarFabricantesViewModel(
                    f.Id,
                    f.Nome,
                    f.Email,
                    f.Telefone
                );

                listaVms.Add(viewModel);
            }

            return View(listaVms);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastrarFabricanteViewModel cadastroVm)
        {
            Fabricante novoFabricante = new Fabricante(
                cadastroVm.Nome,
                cadastroVm.Email,
                cadastroVm.Telefone
            );

            repositorioFabricante.Cadastrar(novoFabricante);

            return RedirectToAction(nameof(Listar));

        }

        [HttpGet]

        public ActionResult Editar(string id)
        {
            Fabricante? fabricante = repositorioFabricante.SelecionarPorId(id);

            if (fabricante == null)
                return RedirectToAction(nameof(Listar));
            return View(fabricante);
        }

        [HttpPost]
        public ActionResult Editar(EditarFabricanteViewModel EditarVm)
        {
            Fabricante fabricanteatualizado = new Fabricante(
                EditarVm.Nome,
                EditarVm.Email,
                EditarVm.Telefone
            );

            repositorioFabricante.Editar(EditarVm.Id, fabricanteatualizado);

            if (fabricanteatualizado == null)
                return RedirectToAction(nameof(Listar));

            return View(fabricanteatualizado);
        }

        [HttpGet]

        public ActionResult Excluir(string id)
        {
            Fabricante? fabricante = repositorioFabricante.SelecionarPorId(id);

            if (fabricante == null)
                return RedirectToAction(nameof(Listar));

            ExcluirFabricanteViewModel ExluirVm = new ExcluirFabricanteViewModel(
                id,
                fabricante.Nome,
                fabricante.Email,
                fabricante.Telefone
            );

            return View(ExluirVm);
        }

        [HttpPost]
        [ActionName("Excluir")]

        public ActionResult ExcluirConfirmado(ExcluirFabricanteViewModel ExluirVm)
        {
            Fabricante? fabricante = (Fabricante?)repositorioFabricante.SelecionarPorId(ExluirVm.Id);

            if (fabricante == null)
                return RedirectToAction(nameof(Listar));

            repositorioFabricante.Excluir(fabricante);

            return View(fabricante);
        }
    }
}
