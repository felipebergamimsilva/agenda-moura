using agenda.Models;
using agenda.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace agenda.Controllers
{
    public class HomeController : Controller
    {
        private ContatoService service;

        public HomeController()
        {
            service = new ContatoService();
        }

        public ActionResult Index()
        {
            HomeModel model = new HomeModel
            {
                Contatos = service.recuperarTodos()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContatoModel contato)
        {
            service.Criar(contato);
            TempData["mensagem"] = "Contato criado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(service.recuperarPorId(id));
        }

        [HttpPost]
        public ActionResult Edit(ContatoModel contato)
        {
            service.Editar(contato);
            TempData["mensagem"] = "Contato editado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            return View(service.recuperarPorId(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(Guid id)
        {
            service.Excluir(id);
            TempData["mensagem"] = "Contato excluido com sucesso!";
            return RedirectToAction("Index");
        }
    }
}