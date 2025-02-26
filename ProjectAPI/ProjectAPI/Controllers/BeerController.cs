using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.DTOs;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private StoreContext _context;

        public BeerController(StoreContext context)
        {
            _context = context;
        } 

        public async Task<IEnumerable<BeerDto>>Get()=>
            _context.Beers.Select(b => new BeerDto
            {
                Id = b.Id,
                Name = b.Name,
                Brand = b.Brand.Name,
                Alcohol = b.Alcohol
            });
    }
}
