using System.Collections.Generic;
using System.IO;
using CasaDoCodigo.AcessoDados;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CasaDoCodigo
{
    class PreencherDados : IPreencherDados
    {
        public readonly ApplicationContext Banco;
        public readonly IProdutoDao ProdutoDao;

        public PreencherDados(ApplicationContext banco, IProdutoDao produtoDao)
        {
            this.ProdutoDao = produtoDao;
            this.Banco = banco;
        }
        public void InicializaDB()
        {
            //garante que o BD é criado.
            Banco.Database.Migrate();
            List<Livro> livros = GetLivros();
            ProdutoDao.SalvarProdutos(livros);
            Banco.SaveChanges();

        }
       
        public static List<Livro> GetLivros()
        {

            //lê o arquivo json
            var json = File.ReadAllText("livros.json");

            //Converte o Json e objeto
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }
}
