using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{

    public class ItemPedido 
    {
        public int Id { get; set; }

        //Propriedade de navegação de referencia
        [Required]
        public virtual Pedido Pedido { get; private set; }
        public int PedidoId { get; private set; }

        //Propriedade de navegação de referencia
        [Required]
        public virtual Produto Produto { get; private set; }
        public int ProdutoId { get; private set; }

        [Required]
        public int Quantidade { get; private set; }

        [Required]
        public double PrecoUnitario { get; private set; }

        public ItemPedido()
        {

        }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade, double precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }
    }
}
