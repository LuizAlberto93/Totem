using Microsoft.AspNetCore.Mvc;
using Totem.Dados.Repositorios;
using Totem.Entidades;

namespace Totem.Web.Controllers
{
    public class PedidoController : Controller
    {
        private readonly PedidoRepositorio _repositorio;

        private readonly ProdutoRepositorio _repositorioProduto;

        public PedidoController(PedidoRepositorio repositorio, ProdutoRepositorio repositorioProduto)
        {
            _repositorio = repositorio;
            _repositorioProduto = repositorioProduto;
        }

        public IActionResult Index()
        {
            List<PedidoViewModel> lst = new List<PedidoViewModel>();
            var pedidos = _repositorio.Buscar();

            foreach (var pedido in pedidos)
            {
                PedidoViewModel model = new PedidoViewModel();
                model.Codigo = pedido.Codigo;
                model.Cliente = pedido.Cliente;
                model.Produto = pedido.Produto;
                model.QtdProdutoPedido = pedido.QtdProdutoPedido;
                model.ValorTotal = pedido.ValorTotal;
                model.DataHora = pedido.DataHora;                
                //model.Nome = produto.Nome.ToString();
                lst.Add(model);
            }

            return View(lst);
        }

        //Criei para a primeira tela
        public IActionResult ListaDePedidos()
        {
            List<PedidoViewModel> lst = new List<PedidoViewModel>();
            var pedidos = _repositorio.Buscar();

            foreach (var pedido in pedidos)
            {
                PedidoViewModel model = new PedidoViewModel();
                model.Codigo = pedido.Codigo;
                model.Cliente = pedido.Cliente;
                model.Produto = pedido.Produto;
                model.QtdProdutoPedido = pedido.QtdProdutoPedido;
                model.ValorTotal = pedido.ValorTotal;
                model.DataHora = pedido.DataHora;
                //model.Nome = produto.Nome.ToString();
                lst.Add(model);
            }

            return View(lst);
        }

        public IActionResult Cadastrar()
        {
            List<ProdutoViewModel> lst = new List<ProdutoViewModel>();
            IEnumerable<Produto> produtos = _repositorioProduto.Buscar();
            PedidoViewModel pedidoModel = new PedidoViewModel();
            pedidoModel.Produto = produtos.ToList();
 
            return View(pedidoModel);
        }
        [HttpPost]
        public IActionResult Cadastrar(PedidoViewModel pedidoViewModel)
        {
            Pedido pedido = new Pedido();
            pedido.Codigo = pedidoViewModel.Codigo;
            pedido.Cliente = pedidoViewModel.Cliente;
            pedido.Produto = pedidoViewModel.Produto;
            pedido.QtdProdutoPedido = pedidoViewModel.QtdProdutoPedido;
            pedido.ValorTotal = pedidoViewModel.ValorTotal;
            pedido.DataHora = pedidoViewModel.DataHora;
            //produto.Nome = produtoViewModel.Nome.ToString();

            var id = _repositorio.Adicionar(pedido);
            foreach (var produto in pedidoViewModel.Produto)
            {
               var produtoBanco = _repositorioProduto.Buscar(produto.Id);
                produtoBanco.QtdEstoque -= produto.QtdEstoque;
                _repositorioProduto.Atualizar(produtoBanco);
            }
            

            return RedirectToAction("Index");
        }


        public IActionResult Remover(int id)
        {
            var pedido = _repositorio.Buscar(id);

            PedidoViewModel model = new PedidoViewModel();
            model.Codigo = pedido.Codigo;
            model.Cliente = pedido.Cliente;
            model.Produto = pedido.Produto;
            model.QtdProdutoPedido = pedido.QtdProdutoPedido;
            model.ValorTotal = pedido.ValorTotal;
            model.DataHora = pedido.DataHora;
            //model.Nome = produto.Nome.ToString();

            return View(model);
        }

        public IActionResult RemoverPorId(int id)
        {
            _repositorio.Excluir(id);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var pedido = _repositorio.Buscar(id);

            PedidoViewModel model = new PedidoViewModel();
            model.Codigo = pedido.Codigo;
            model.Cliente = pedido.Cliente;
            model.Produto = pedido.Produto;
            model.QtdProdutoPedido = pedido.QtdProdutoPedido;
            model.ValorTotal = pedido.ValorTotal;
            model.DataHora = pedido.DataHora;
            //model.Nome = produto.Nome.ToString();

            return View(model);
        }

        public IActionResult EditarPorId(PedidoViewModel pedidoViewModel)
        {
            Pedido pedido = new Pedido();
            pedido.Codigo = pedidoViewModel.Codigo;
            pedido.Cliente = pedidoViewModel.Cliente;
            pedido.Produto = pedidoViewModel.Produto;
            pedido.QtdProdutoPedido = pedidoViewModel.QtdProdutoPedido;
            pedido.ValorTotal = pedidoViewModel.ValorTotal;
            pedido.DataHora = pedidoViewModel.DataHora;
            //produto.Nome = produtoViewModel.Nome.ToString();

            _repositorio.Atualizar(pedido);

            return RedirectToAction("Index");
        }
    }
}
