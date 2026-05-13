using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado;
using GestaoDeEquipamentosWeb.ConsoleApp.Compartilhado.Arquivos;
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
        public ActionResult Listar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar(string nome, string email, string telefone)
        {
            Fabricante novoFabricante = new Fabricante(nome, email, telefone);
            repositorioFabricante.Cadastrar(novoFabricante);

            return RedirectToAction(nameof(Listar));

        }

    }
}
