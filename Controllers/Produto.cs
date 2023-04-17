using Models;
using System;
using System.Linq;

namespace Controllers
{
    public class Produto
    {
        private Context Context;

        public Produto(Context context)
        {
            Context = context;
        }

        public void Criar(string nome, double preco)
        {
            Models.Produto produto = new Models.Produto(nome, preco);

            Context.Produto.Add(produto);
            Context.SaveChanges();
        }

        public void Alterar(int id, string nome,double preco)
        {
            Models.Produto produto = Context.Produtos.Where(produto => produto.Id.Equals(id)).FirstOrDefault();

            if (produto == null)
                throw new Exception("Produto não encontrado");

            produto.Nome = nome;
            produto.Preco = preco;
            Context.SaveChanges();

        }

        public void Excluir(int id)
        {
            Models.Produto produto = Context.Produtos.Where(produto => produto.Id.Equals(id)).FirstOrDefault();

            if (produto == null)
                throw new Exception("Produto não encontrado");

            Context.Remove(produto);
        }

        public List<Models.Produto> Listar()
        {
            return Context.Produtos.ToList();
        }

        public Models.Produto GetById(int id) {
            return Context.Produtos.Where(produto => produto.Id.Equals(id)).FirstOrDefault();
        }
    }
}