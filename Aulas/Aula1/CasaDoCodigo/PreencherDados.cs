using CasaDoCodigo.AcessoDados;
using CasaDoCodigo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

class PreencherDados : IPreencherDados
{
    public readonly ApplicationContext banco;
    public readonly IProdutoDao produtoDao;

    public PreencherDados(ApplicationContext banco, IProdutoDao produtoDao)
    {
        this.produtoDao = produtoDao;
        this.banco = banco;
    }
    public void InicializaDB()
    {
        //garante que o BD é criado.
        banco.Database.EnsureCreated();
        List<Livro> livros = GetLivros();
        produtoDao.SalvarProdutos(livros);

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
