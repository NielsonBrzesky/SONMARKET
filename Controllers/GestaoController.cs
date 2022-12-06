using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SONMARKET.Data;
using SONMARKET.DTO;

namespace SONMARKET.Controllers
{
    public class GestaoController : Controller
    {
        private readonly ApplicationDbContext database;
        public GestaoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Categorias()
        {
            var categorias = database.Categorias.Where(cat => cat.Status.Equals(true)).ToList();
            return View(categorias);
        }

        public IActionResult NovaCategoria()
        {
            return View();
        }

        public IActionResult EditarCategoria(int id)
        {
            var categoria = database.Categorias.First(cat => cat.Id == id);
            CategoriaDTO categoriaView = new CategoriaDTO();
            categoriaView.Id = categoria.Id;
            categoriaView.Nome = categoria.Nome;
            return View(categoriaView);
        }

        public IActionResult Fornecedores()
        {
            var fornecedores = database.Fornecedores.Where(forne => forne.Status.Equals(true)).ToList();
            return View(fornecedores);
        }

        public IActionResult EditarFornecedor(int id)
        {
            var fornecedor = database.Fornecedores.First(forne => forne.Id == id);
            FornecedorDTO fornecedorView = new FornecedorDTO();
            fornecedorView.Id = fornecedor.Id;
            fornecedorView.Nome = fornecedor.Nome;
            fornecedorView.Email = fornecedor.Email;
            fornecedorView.Telefone = fornecedor.Telefone;
            return View(fornecedorView);
        }

        public IActionResult NovoFornecedor()
        {
            return View();
        }

        public IActionResult Produtos()
        {
            var produtos = database.Produtos.Include(p => p.Categoria).Include(f => f.Fornecedor)
                .Where(p => p.Status.Equals(true)).ToList();
            return View(produtos);
        }

        public IActionResult NovoProduto()
        {
            ViewBag.Categorias = database.Categorias.ToList(); //Trás a lista de Categorias dentro do banco.
            ViewBag.Fornecedores = database.Fornecedores.ToList();
            return View();
        }

        public IActionResult EditarProduto(int id)
        {
            var produto = database.Produtos.Include(p => p.Categoria).Include(f => f.Fornecedor).First(p => p.Id == id);
            ProdutoDTO produtoView = new ProdutoDTO();
            produtoView.Id = produto.Id;
            produtoView.Nome = produto.Nome;
            produtoView.PrecoDeCusto = produto.PrecoDeCusto;
            produtoView.PrecoDeVenda = produto.PrecoDeVenda;
            produtoView.CategoriaID = produto.Categoria.Id;
            produtoView.FornecedorID = produto.Fornecedor.Id;
            produtoView.Medicao = produto.Medicao;
            ViewBag.Categorias = database.Categorias.ToList(); //Trás a lista de Categorias dentro do banco.
            ViewBag.Fornecedores = database.Fornecedores.ToList();
            return View(produtoView);
        }

        public IActionResult Promocoes()
        {
            var promocoes = database.Promocoes.Include(p => p.Produto)
                .Where(promo => promo.Status.Equals(true)).ToList();
            return View(promocoes);
        }

        public IActionResult NovaPromocao()
        {
            ViewBag.Produtos = database.Produtos.ToList();
            return View();
        }

        public IActionResult EditarPromocao(int id)
        {
            var promocao = database.Promocoes.Include(p => p.Produto).First(pro => pro.Id.Equals(id));
            PromocaoDTO promoView = new PromocaoDTO();
            promoView.Id = promocao.Id;
            promoView.Nome = promocao.Nome;
            promoView.Porcentagem = promocao.Porcentagem;
            promoView.ProdutoID = promocao.Produto.Id;
            ViewBag.Produtos = database.Produtos.ToList();
            return View(promoView);
        }

        public IActionResult Estoque() {
            var listaEstoque = database.Estoques.Include(e => e.Produto).ToList();
            return View(listaEstoque);
        }

         public IActionResult NovoEstoque() {
            ViewBag.Produtos = database.Produtos.ToList();
            return View();
        }

         public IActionResult EditarEstoque() {
            return Content("");
        }


    }
}