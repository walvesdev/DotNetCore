using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }

    public class Produto : BaseModel
    {
        public Produto()
        {

        }

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

    public class Cadastro : BaseModel
    {
        public Cadastro()
        {
        }

        public virtual Pedido Pedido { get; set; }
        public int PedidoId { get; set; }

        [Required]
        public string Nome { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Telefone { get; set; } = "";
        [Required]
        public string Endereco { get; set; } = "";
        [Required]
        public string Complemento { get; set; } = "";
        [Required]
        public string Bairro { get; set; } = "";
        [Required]
        public string Municipio { get; set; } = "";
        [Required]
        public string UF { get; set; } = "";
        [Required]
        public string CEP { get; set; } = "";
    }

    public class ItemPedido : BaseModel
    {   
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

    public class Pedido : BaseModel
    {
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
