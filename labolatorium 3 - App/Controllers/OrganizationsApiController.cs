using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace labolatorium_3___App.Controllers
{
    [Route("api/OrganizationsApi")]
    [ApiController]
    public class OrganizationsApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizationsApiController(AppDbContext context)
        {
            _context = context;
        }

        
        public IActionResult GetFiltered(string filter)
        {
            var result = _context.Organizations
                .Where(o => o.Name.ToUpper().StartsWith(filter.ToUpper()))
                .Select(o => new
                {
                    Id= o.Id,
                    Name = o.Name
                }
                )
                .ToList();  

            return Ok(result);
        }

        [Route("{id}")]
        public IActionResult GetOrganizationByID(int id)
        {
            var entity = _context.Organizations.Find(id);
            if(entity is null)
                return NotFound();
            else
            return Ok(entity);
        }
    }
}
