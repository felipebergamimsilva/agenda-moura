using agenda.Models;
using agenda.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace agenda.Services
{
    public class ContatoService
    {
        private ContatoRepository repository;

        public ContatoService()
        {
            repository = new ContatoRepository(ConfigurationManager.AppSettings["arquivo"]);
        }

        public List<ContatoModel> recuperarTodos()
        {
            return repository.recuperarTodos();
        }

        public ContatoModel recuperarPorId(Guid id)
        {
            return repository.recuperarPorId(id);
        }

        public void Criar(ContatoModel contato)
        {
            contato.Id = Guid.NewGuid();
            repository.Criar(contato);
        }

        public void Editar(ContatoModel contato)
        {
            repository.Editar(contato);
        }

        public void Excluir(Guid id)
        {
            repository.Excluir(id);
        }
    }
}