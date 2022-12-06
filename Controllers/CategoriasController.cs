using Microsoft.AspNetCore.Mvc;
using SONMARKET.Data;
using SONMARKET.DTO;
using SONMARKET.Models;

namespace SONMARKET.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext database;
        public CategoriasController(ApplicationDbContext database) {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(CategoriaDTO categoriaTemporaria) {
            if(ModelState.IsValid) {
                Categoria categoria = new Categoria();
                categoria.Nome = categoriaTemporaria.Nome;
                categoria.Status = true;
                database.Categorias.Add(categoria);
                database.SaveChanges();
                return RedirectToAction("Categorias", "Gestao");
            }else{
                return View("../Gestao/NovaCategoria");
            }
        }

        public IActionResult Atualizar(CategoriaDTO categoriaTemporaria) {

            if(ModelState.IsValid) {
                var categoria = database.Categorias.First(cat => cat.Id == categoriaTemporaria.Id);
                categoria.Nome = categoriaTemporaria.Nome;
                database.SaveChanges();
                return RedirectToAction("Categorias", "Gestao");
            } else {
                return View("../Gestao/EditarCategoria");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id) {
            if(id > 0) {
                var categoria = database.Categorias.First(cat => cat.Id == id);
                categoria.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Categorias", "Gestao");
            //return Content(id.ToString());
        }
    }
}