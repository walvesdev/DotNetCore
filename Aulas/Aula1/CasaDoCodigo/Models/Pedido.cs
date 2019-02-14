using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{
    public class Pedido 
    {
        public int Id { get; set; }

        public Pedido()
        {
            Cadastro = new Cadastro();
        }

        public Pedido(Cadastro cadastro)
        {
            Cadastro = cadastro;
        }

        //Propriedade de navegação de coleção
        public virtual ICollection<ItemPedido> ItemPedido { get; private set; }

        //Propriedade de navegação de referencia
        [Required]
        public virtual Cadastro Cadastro { get; private set; }
    }
}
