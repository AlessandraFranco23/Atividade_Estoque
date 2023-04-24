using Models;
using System;
using System.Linq;

namespace Controllers
{
    public class Produto
    {
        public void Criar(string nome, double preco)
        {
            using var context = new Models.Context();

            Models.Produto produto = new Models.Produto(nome, preco);
            context.Produtos.Add(produto);
            context.SaveChanges();
        }

        public void Alterar(int id, string nome, double preco)
        {
            using var context = new Models.Context();

            Models.Produto produto = context.Produtos.Where(produto => produto.Id.Equals(id)).FirstOrDefault();

            if (produto == null)
                throw new Exception("Produto não encontrado");

            produto.Nome = nome;
            produto.Preco = preco;
            context.SaveChanges();

        }

        public void Excluir(int id)
        {
            using var context = new Models.Context();

            Models.Produto produto = context.Produtos.Where(produto => produto.Id.Equals(id)).FirstOrDefault();

            if (produto == null)
                throw new Exception("Produto não encontrado");

            context.Produtos.Remove(produto);
            context.SaveChanges();
        }

        public List<Models.Produto> Listar()
        {
            using var context = new Models.Context();

            return context.Produtos.ToList();
        }

        public Models.Produto GetById(int id)
        {
            using var context = new Models.Context();

            return context.Produtos.Where(produto => produto.Id.Equals(id)).FirstOrDefault();
        }
    }
}