using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.AcessoDados
{
    public class ProdutoDao : RepositorioBase<Produto>, IProdutoDao
    {
        public ProdutoDao(ApplicationContext banco) : base(banco)
        {
        }

        public List<Produto> ListarTodos()
        {
            return dbset.ToList();
        }

        public void SalvarProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if (!dbset.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    dbset.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }

        }
    }
}
