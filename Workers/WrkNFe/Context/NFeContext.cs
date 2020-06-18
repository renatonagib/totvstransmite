using Microsoft.EntityFrameworkCore; 
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql;
using System;
using Workers.WrkNFe.Models;

namespace Workers.WrkNFe.Context
{
    public class NFeContext: DbContext
    {
        public DbSet<NFe> NFes { get; set; }
        
        /*
        public NFeContext(DbContextOptions<NFeContext> options): base(options){
            var teste = "teste";   
        }
        */
        protected override void OnConfiguring(DbContextOptionsBuilder options){
            var host = Environment.GetEnvironmentVariable("DBHOST");
            Console.WriteLine("nome do Host: " + host);                                
            options.UseNpgsql("Server=" + host + ";Port=5432;Database=postgres;User Id=postgres;Password=123;");
        }

        
        
    } 
}