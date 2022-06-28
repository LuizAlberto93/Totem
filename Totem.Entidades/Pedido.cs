using System.ComponentModel.DataAnnotations;

namespace Totem.Entidades
{
    public class Pedido
    {
        [Key]
        public int Codigo { get; set; }
        public string Cliente { get; set; }
        public List<Produto> Produto { get; set; }
        public int QtdProdutoPedido { get; set; }
        public float ValorTotal { get; set; }
        public DateTime DataHora { get; set; }

             
        //public int StatusId { get; set; }
        //public virtual Status Status { get; set; }
    }
}
