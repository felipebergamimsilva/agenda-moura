using agenda.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace agenda.Repository
{
    public abstract class BaseRepository
    {
        public string Arquivo { get; set; }

        public BaseRepository(string arquivo)
        {
            Arquivo = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, arquivo));
        }

        protected string LerArquivo()
        {
            return File.ReadAllText(Arquivo);
        }

        public void EscreverArquivo(List<ContatoModel> contatos)
        {
            File.WriteAllText(Arquivo, JsonConvert.SerializeObject(contatos), Encoding.UTF8);
        }
    }
}