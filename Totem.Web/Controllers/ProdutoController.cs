using Microsoft.AspNetCore.Mvc;
using Totem.Dados.Repositorios;
using Totem.Entidades;

namespace Totem.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepositorio _repositorio;

        public ProdutoController(ProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Consulta()
        {
            List<ProdutoViewModel> lst = new List<ProdutoViewModel>();
            var produtos = _repositorio.Buscar();

            foreach (var produto in produtos)
            {
                ProdutoViewModel model = new ProdutoViewModel();
                model.Id = produto.Id;
                model.Nome = produto.Nome;
                model.ValorUnitario = produto.ValorUnitario;
                model.QtdEstoque = produto.QtdEstoque;
                model.PedidoId = produto.PedidoId;
                model.Pedido = produto.Pedido;
                //model.Nome = produto.Nome.ToString();
                lst.Add(model);
            }

            return View(lst);
        }

        //Criei para a primeira tela
        public IActionResult ListaDeProdutos()
        {
            List<ProdutoViewModel> lst = new List<ProdutoViewModel>();
            var produtos = _repositorio.Buscar();

            foreach (var produto in produtos)
            {
                ProdutoViewModel model = new ProdutoViewModel();
                model.Id = produto.Id;
                model.Nome = produto.Nome;
                model.ValorUnitario = produto.ValorUnitario;
                model.QtdEstoque = produto.QtdEstoque;
                model.PedidoId = produto.PedidoId;
                model.Pedido = produto.Pedido;
                //model.Nome = produto.Nome.ToString();
                lst.Add(model);
            }

            return View(lst);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(ProdutoViewModel produtoViewModel)
        {
            Produto produto = new Produto();
            produto.Id = produtoViewModel.Id;
            produto.Nome = produtoViewModel.Nome;
            produto.ValorUnitario = produtoViewModel.ValorUnitario;
            produto.QtdEstoque = produtoViewModel.QtdEstoque;
            produto.PedidoId = produtoViewModel.PedidoId;
            produto.Pedido = produtoViewModel.Pedido;
            //produto.Nome = produtoViewModel.Nome.ToString();

            var id = _repositorio.Adicionar(produto);

            return RedirectToAction("Consulta");
        }


        public IActionResult Remover(int id)
        {
            var produto = _repositorio.Buscar(id);

            ProdutoViewModel model = new ProdutoViewModel();
            model.Id = produto.Id;
            model.Nome = produto.Nome;
            model.ValorUnitario = produto.ValorUnitario;
            model.QtdEstoque = produto.QtdEstoque;
            model.PedidoId = produto.PedidoId;
            model.Pedido = produto.Pedido;
            //model.Nome = produto.Nome.ToString();

            return View(model);
        }

        public IActionResult RemoverPorId(int id)
        {
            _repositorio.Excluir(id);
            return RedirectToAction("Consulta");
        }

        public IActionResult Editar(int id)
        {
            var produto = _repositorio.Buscar(id);

            ProdutoViewModel model = new ProdutoViewModel();
            model.Id = produto.Id;
            model.Nome = produto.Nome;
            model.ValorUnitario = produto.ValorUnitario;
            model.QtdEstoque = produto.QtdEstoque;
            model.PedidoId = produto.PedidoId;
            model.Pedido = produto.Pedido;
            //model.Nome = produto.Nome.ToString();

            return View(model);
        }

        public IActionResult EditarPorId(ProdutoViewModel produtoViewModel)
        {
            Produto produto = new Produto();
            produto.Id = produtoViewModel.Id;
            produto.Nome = produtoViewModel.Nome;
            produto.ValorUnitario = produtoViewModel.ValorUnitario;
            produto.QtdEstoque = produtoViewModel.QtdEstoque;
            produto.PedidoId = produtoViewModel.PedidoId;
            produto.Pedido = produtoViewModel.Pedido;
            //produto.Nome = produtoViewModel.Nome.ToString();

            _repositorio.Atualizar(produto);

            return RedirectToAction("Consulta");
        }
    }
}
