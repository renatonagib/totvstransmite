using System;
using System.ComponentModel.DataAnnotations;

namespace API_EDI.Models
{
    public class Conteudo
    {        
        public string DocumentId { get; set; }
        public string EntidadeId { get; set; }
        public int Ambiente { get; set; }
        public int Modalidade { get; set; }
        public string Xml { get; set; }
        public DateTime DataRecepcao { get; set;}
        public int StatusDistribuicao { get; set; }
        public string CorrelationId { get; set; }
        public int Status { get; set; }    
    }

}