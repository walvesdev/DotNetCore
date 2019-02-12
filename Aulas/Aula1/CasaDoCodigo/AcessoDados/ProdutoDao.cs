using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.AcessoDados
{
    public class ProdutoDao : IProdutoDao
    {
        public readonly ApplicationContext banco;

        public ProdutoDao(ApplicationContext banco)
        {
            this.banco = banco;
        }

        public List<Produto> ListarTodos()
        {
            return banco.Set<Produto>().ToList();
        }

        public void SalvarProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                banco.Set<Produto>().Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
            }
            banco.SaveChanges();

        }
    }
}
