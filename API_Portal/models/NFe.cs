using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore; 

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Portal.models
{
    [Table("NFes")]
    public class NFe
    {        
        [Key]
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