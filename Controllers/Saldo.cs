using Models;
using System;
using System.Linq;

namespace Controllers
{
    public class Saldo
    {
        private Context Context;

        public Saldo(Context context)
        {
            Context = context;
        }

        public void Criar(int produtoId, int almoxarifadoId, int quantidade)
        {
            Models.Produto produto = Context.Produtos.Where(p => p.Id == produtoId).FirstOrDefault();
            if (produto == null) {
                throw new Exception("Produto inexistente!");
            }

            Models.Almoxarifado almoxarifado = Context.Almoxarifados.Where(a => a.Id == almoxarifadoId).FirstOrDefault();
            if (almoxarifado == null) {
                throw new Exception("Almoxarifado inexistente!");
            }

            Models.Saldo saldoExistente = Context.Saldos.Where(s => s.AlmoxarifadoId == almoxarifadoId && s.ProdutoId == produtoId).FirstOrDefault();
            if (saldoExistente != null) {
                throw new Exception("Produto já cadastrado para esse almoxarifado!");
            }

            Models.Saldo saldo = new Models.Saldo((Context.Saldos.Count + 1), produto, almoxarifado, quantidade);
            Context.Saldos.Add(saldo);
            // Context.SaveChanges();
        }

        public void Alterar(int id, int produtoId, int almoxarifadoId, int quantidade)
        {
            Models.Saldo saldo = Context.Saldos.Where(Saldo => Saldo.Id.Equals(id)).FirstOrDefault();

            if (saldo == null)
                throw new Exception("Saldo não encontrado");

            saldo.ProdutoId = produtoId;
            saldo.AlmoxarifadoId = almoxarifadoId;
            saldo.Quantidade = quantidade;
            // Context.SaveChanges();

        }

        public void Excluir(int id)
        {
            Models.Saldo saldo = Context.Saldos.Where(saldo => saldo.Id.Equals(id)).FirstOrDefault();

            if (saldo == null)
                throw new Exception("Saldo não encontrado");

            Context.Saldos.Remove(saldo);
        }

        public List<Models.Saldo> Listar()
        {
            return Context.Saldos.ToList();
        }

        public Models.Saldo GetById(int id) {
            return Context.Saldos.Where(saldo => saldo.Id.Equals(id)).FirstOrDefault();
        }
    }
}