using Microsoft.EntityFrameworkCore; 
using API_Portal.models;
using System.Collections.Generic;

namespace API_Portal.Context
{
    public class NFeContext: DbContext
    {
        public NFeContext(DbContextOptions<NFeContext> options): base(options){
        }

        public DbSet<NFe> NFes { get; set; }
        
    }
}