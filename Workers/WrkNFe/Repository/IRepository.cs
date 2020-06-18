using System.Collections.Generic;
using Workers.WrkNFe.Models;

namespace Workers.WrkNFe.Repository
{
    public interface IRepository
    {
         IEnumerable<NFe> NFes {get;}
    }
}