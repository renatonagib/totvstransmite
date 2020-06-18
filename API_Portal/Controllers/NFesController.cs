using Microsoft.AspNetCore.Mvc;
using API_Portal.models;
using System.Collections.Generic;
using API_Portal.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API_Portal.Controllers

{
    [Route("api/[Controller]")]
    [ApiController]
    public class NFesController : ControllerBase
    {
        private readonly NFeContext _context;
        public NFesController(NFeContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NFe>>> Get()
        {
            return await _context.NFes.AsNoTracking().ToListAsync();
        }

         [HttpGet("{id}", Name = "ObterNFe")]
        public ActionResult<NFe> Get(string id)
        {
            var nfe = _context.NFes.AsNoTracking().FirstOrDefault(p => p.DocumentId == id);
            if(nfe == null)
            {
                NotFound();
            }
            return nfe;
        }

        [HttpPost]
        public ActionResult Post([FromBody] NFe nfe )
        {
            _context.NFes.Add(nfe);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterNFe", 
                new { id = nfe.DocumentId}, nfe);
        }
        
        [HttpPut("{id}")]
        public ActionResult Put( string id, [FromBody] NFe nfe )
        {
            if(id != nfe.DocumentId ){
                return BadRequest();
            }            
            _context.Entry(nfe).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<NFe> Delete(string id)
         {
            var nfe = _context.NFes.AsNoTracking().FirstOrDefault(p => p.DocumentId == id);
            if(nfe == null)
            {
                NotFound();
            }
            _context.NFes.Remove(nfe);
            _context.SaveChanges();
            return nfe;
        }
        
    }
}