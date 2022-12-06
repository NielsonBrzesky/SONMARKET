using Microsoft.AspNetCore.Mvc;
using SONMARKET.Data;
using SONMARKET.DTO;
using SONMARKET.Models;

namespace SONMARKET.Controllers
{
    public class PromocoesController : Controller
    {
        private readonly ApplicationDbContext database;

        public PromocoesController(ApplicationDbContext database)
        {
            this.database = database;
        }


        [HttpPost]
        public IActionResult Salvar(PromocaoDTO promocaoTemporaria)
        {
            if (ModelState.IsValid)
            {
                Promocao promocao = new Promocao();
                promocao.Nome = promocaoTemporaria.Nome;
                promocao.Produto = database.Produtos.First(prod => prod.Id.Equals(promocaoTemporaria.ProdutoID));
                promocao.Porcentagem = promocaoTemporaria.Porcentagem;
                promocao.Status = true;
                database.Promocoes.Add(promocao);
                database.SaveChanges();
                return RedirectToAction("Promocoes", "Gestao");
            }
            else
            {
                ViewBag.Produtos = database.Produtos.ToList();
                return View("../Getao/NovaPromocao");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(PromocaoDTO promocaoTemporaria)
        {
            if (ModelState.IsValid)
            {
                var promocao = database.Promocoes.First(promo => promo.Id.Equals(promocaoTemporaria.Id));
                promocao.Nome = promocaoTemporaria.Nome;
                promocao.Porcentagem = promocaoTemporaria.Porcentagem;
                promocao.Produto = database.Produtos.First(prod => prod.Id.Equals(promocaoTemporaria.ProdutoID));
                database.SaveChanges();
                return RedirectToAction("Promocoes", "Gestao");
            }
            else
            {
                return RedirectToAction("Promocoes", "Gestao");
            }
        }

        public IActionResult Deletar(int id)
        {
            if (id > 0)
            {
                var promocao = database.Promocoes.First(promo => promo.Id.Equals(id));
                promocao.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Promocoes", "Gestao");
        }
    }
}