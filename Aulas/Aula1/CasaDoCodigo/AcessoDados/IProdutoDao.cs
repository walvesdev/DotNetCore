using System.Collections.Generic;
using CasaDoCodigo.Models;

namespace CasaDoCodigo.AcessoDados
{
    public interface IProdutoDao
    {
        void SalvarProdutos(List<Livro> livros);
        List<Produto> ListarTodos();
    }
}