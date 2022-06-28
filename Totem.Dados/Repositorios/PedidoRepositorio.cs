using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totem.Entidades;

namespace Totem.Dados.Repositorios
{
    public class PedidoRepositorio
    {
        private readonly Contexto _contexto;

        public PedidoRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public int Adicionar(Pedido pedido)
        {

            foreach (var p in pedido.Produto) 
            { 
                
            
            }
            _contexto.Add(pedido);
            return _contexto.SaveChanges();
        }

        public void Atualizar(Pedido pedido)
        {
            _contexto.Entry(pedido).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<Pedido> Buscar()
        {
            return _contexto.Pedido.AsEnumerable();
        }

        public Pedido Buscar(int id)
        {
            return _contexto.Pedido.FirstOrDefault(x => x.Codigo == id);
        }

        public void Excluir(int id)
        {
            _contexto.Remove(_contexto.Pedido.FirstOrDefault(x => x.Codigo == id));
            _contexto.SaveChanges();
        }
    }
}
