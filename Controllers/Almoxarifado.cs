using Models;
using System;
using System.Linq;

namespace Controllers
{
    public class Almoxarifado
    {
        private Context Context;

        public Almoxarifado(Context context)
        {
            Context = context;
        }

        public void Criar(string nome)
        {
            Models.Almoxarifado almoxarifado = new Models.Almoxarifado((Context.Almoxarifados.Count + 1), nome);
            Context.Almoxarifados.Add(almoxarifado);
            // Context.SaveChanges();
        }

        public void Alterar(int id, string nome)
        {
            Models.Almoxarifado almoxarifado = Context.Almoxarifados.Where(almoxarifado => almoxarifado.Id.Equals(id)).FirstOrDefault();

            if (almoxarifado == null)
                throw new Exception("Almoxarifado não encontrado");

            almoxarifado.Nome = nome;
            // Context.SaveChanges();

        }

        public void Excluir(int id)
        {
            Models.Almoxarifado almoxarifado = Context.Almoxarifados.Where(almoxarifado => almoxarifado.Id.Equals(id)).FirstOrDefault();

            if (almoxarifado == null)
                throw new Exception("Almoxarifado não encontrado");

            Context.Almoxarifados.Remove(almoxarifado);
        }

        public List<Models.Almoxarifado> Listar()
        {
            return Context.Almoxarifados.ToList();
        }

        public Models.Almoxarifado GetById(int id) {
            return Context.Almoxarifados.Where(almoxarifado => almoxarifado.Id.Equals(id)).FirstOrDefault();
        }
    }
}