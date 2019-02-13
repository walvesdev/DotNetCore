using CasaDoCodigo.AcessoDados;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoDao produtoDao;

        public PedidoController(IProdutoDao produtoDao)
        {
            this.produtoDao = produtoDao;
        }

        public IActionResult Carrossel()
        {
            return View(produtoDao.ListarTodos());
        }

        public IActionResult Carrinho()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Resumo()
        {
            return View();
        }

    }
}
