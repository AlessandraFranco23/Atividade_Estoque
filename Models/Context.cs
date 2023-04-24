using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Models
{
    // public class Context
    // {

    //     public List<Produto> Produtos = new List<Produto>();
    //     public List<Almoxarifado> Almoxarifados = new List<Almoxarifado>();
    //     public List<Saldo> Saldos = new List<Saldo>();

    // }

    public class Context : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Almoxarifado> Almoxarifados { get; set; }
        public DbSet<Saldo> Saldos { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;DataBase=estoque;Uid=root;Pwd=", options => options.EnableRetryOnFailure());
        }
    }
}