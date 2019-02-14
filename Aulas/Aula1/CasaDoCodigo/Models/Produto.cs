using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{
    public class Produto 
    {
        public Produto()
        {

        }

        public int Id { get; set; }
        [Required]
        public string Codigo { get; private set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        public double Preco { get; private set; }

        //Propriedade de navegação de coleção
        public virtual ICollection<ItemPedido> ItemPedido { get; private set; }

        public Produto(string codigo, string nome, double preco)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco;
        }
    }
}
