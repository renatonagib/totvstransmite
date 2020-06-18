using System.Collections.Generic;
using Workers.WrkNFe.Models;
using Workers.WrkNFe.Context;

namespace Workers.WrkNFe.Repository
{
    public class NFeRepository:IRepository
    {
        private NFeContext context;

        public NFeRepository(NFeContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<NFe> NFes => context.NFes;
    }
}