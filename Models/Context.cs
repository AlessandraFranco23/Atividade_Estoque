using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Context
    {

        public List<Produto> Produtos = new List<Produto>();
        
    }

    // public class Context: DbContext
    // {

    //     public DbSet<Produto> Produtos {get; set;}
        
    //         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     {
    //         optionsBuilder.UseMySql("Server=localhost;DataBase=Controle;Uid=root;Pwd=", options => options.EnableRetryOnFailure());
    //     }
    // }
}