using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Linq;

namespace Controllers
{
    public class Saldo
    {
        public void Criar(int produtoId, int almoxarifadoId, int quantidade)
        {
            using var context = new Models.Context();

            Models.Produto produto = context.Produtos.Where(p => p.Id == produtoId).FirstOrDefault();
            if (produto == null)
            {
                throw new Exception("Produto inexistente!");
            }

            Models.Almoxarifado almoxarifado = context.Almoxarifados.Where(a => a.Id == almoxarifadoId).FirstOrDefault();
            if (almoxarifado == null)
            {
                throw new Exception("Almoxarifado inexistente!");
            }

            Models.Saldo saldoExistente = context.Saldos.Where(s => s.Almoxarifado.Id == almoxarifadoId && s.Produto.Id == produtoId).FirstOrDefault();
            if (saldoExistente != null)
            {
                throw new Exception("Produto já cadastrado para esse almoxarifado!");
            }

            Models.Saldo saldo = new Models.Saldo(produto, almoxarifado, quantidade);
            context.Saldos.Add(saldo);
            context.SaveChanges();
        }

        public void Alterar(int id, int produtoId, int almoxarifadoId, int quantidade)
        {
            using var context = new Models.Context();


            Models.Produto produto = context.Produtos.Where(p => p.Id == produtoId).FirstOrDefault();
            if (produto == null)
            {
                throw new Exception("Produto inexistente!");
            }

            Models.Almoxarifado almoxarifado = context.Almoxarifados.Where(a => a.Id == almoxarifadoId).FirstOrDefault();
            if (almoxarifado == null)
            {
                throw new Exception("Almoxarifado inexistente!");
            }

            Models.Saldo saldo = context.Saldos.Where(Saldo => Saldo.Id.Equals(id)).FirstOrDefault();

            if (saldo == null)
                throw new Exception("Saldo não encontrado");

            saldo.Produto = produto;
            saldo.Almoxarifado = almoxarifado;
            saldo.Quantidade = quantidade;
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            using var context = new Models.Context();

            Models.Saldo saldo = context.Saldos.Where(saldo => saldo.Id.Equals(id)).FirstOrDefault();

            if (saldo == null)
                throw new Exception("Saldo não encontrado");

            context.Saldos.Remove(saldo);
             context.SaveChanges();
        }

        public List<Models.Saldo> Listar()
        {
            using var context = new Models.Context();

            return context.Saldos.Include(p => p.Produto).Include(p => p.Almoxarifado).ToList();
        }

            public Models.Saldo GetById(int id)
        {
            using var context = new Models.Context();

            return context.Saldos.Where(saldo => saldo.Id.Equals(id)).Include(p => p.Produto).Include(p => p.Almoxarifado).FirstOrDefault();
        }
    }
}