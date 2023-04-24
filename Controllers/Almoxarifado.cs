using Models;
using System;
using System.Linq;

namespace Controllers
{
    public class Almoxarifado
    {
        public void Criar(string nome)
        {
            using var context = new Models.Context();

            Models.Almoxarifado almoxarifado = new Models.Almoxarifado( nome);
            context.Almoxarifados.Add(almoxarifado);
            context.SaveChanges();
        }

        public void Alterar(int id, string nome)
        {
            using var context = new Models.Context();

            Models.Almoxarifado almoxarifado = context.Almoxarifados.Where(almoxarifado => almoxarifado.Id.Equals(id)).FirstOrDefault();

            if (almoxarifado == null)
                throw new Exception("Almoxarifado não encontrado");

            almoxarifado.Nome = nome;
            context.SaveChanges();

        }

        public void Excluir(int id)
        {
            using var context = new Models.Context();

            Models.Almoxarifado almoxarifado = context.Almoxarifados.Where(almoxarifado => almoxarifado.Id.Equals(id)).FirstOrDefault();

            if (almoxarifado == null)
                throw new Exception("Almoxarifado não encontrado");

            context.Almoxarifados.Remove(almoxarifado);
             context.SaveChanges();
        }

        public List<Models.Almoxarifado> Listar()
        {
            using var context = new Models.Context();

            return context.Almoxarifados.ToList();
        }

        public Models.Almoxarifado GetById(int id) {
            using var context = new Models.Context();

            return context.Almoxarifados.Where(almoxarifado => almoxarifado.Id.Equals(id)).FirstOrDefault();
        }
    }
}