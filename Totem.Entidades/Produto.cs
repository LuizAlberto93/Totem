using System.ComponentModel.DataAnnotations;

namespace Totem.Entidades
{
 
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public float ValorUnitario { get; set; }
        public int QtdEstoque { get; set; }
        public int? PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

    }
}
