using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totem.Entidades;

namespace Totem.Dados.Repositorios
{
    public class ProdutoRepositorio
    {
        private readonly Contexto _contexto;

        public ProdutoRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public int Adicionar(Produto produto)
        {
            _contexto.Add(produto);
            return _contexto.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            _contexto.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<Produto> Buscar()
        {
            return _contexto.Produto.AsEnumerable();
        }

        public Produto Buscar(int id)
        {
            return _contexto.Produto.FirstOrDefault(x => x.Id == id);
        }

        public void Excluir(int id)
        {
            _contexto.Remove(_contexto.Produto.FirstOrDefault(x => x.Id == id));
            _contexto.SaveChanges();
        }
    }
}
