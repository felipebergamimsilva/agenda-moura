using agenda.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agenda.Repository
{
    public class ContatoRepository : BaseRepository
    {
        public ContatoRepository(string arquivo) : base(arquivo)
        {
        }

        public List<ContatoModel> recuperarTodos()
        {
            var contatos = JsonConvert.DeserializeObject<List<ContatoModel>>(LerArquivo());
            return contatos ?? new List<ContatoModel>();
        }

        public ContatoModel recuperarPorId(Guid id)
        {
            return recuperarTodos().First(c => c.Id == id);
        }

        public void Criar(ContatoModel contato)
        {
            var contatos = recuperarTodos();
            contatos.Add(contato);
            EscreverArquivo(contatos);
        }

        public void Editar(ContatoModel contato)
        {
            var contatos = recuperarTodos();
            contatos.RemoveAll(c => c.Id == contato.Id);
            contatos.Add(contato);
            EscreverArquivo(contatos);
        }

        public void Excluir(Guid id)
        {
            var contatos = recuperarTodos();
            contatos.RemoveAll(c => c.Id == id);
            EscreverArquivo(contatos);
        }
    }
}