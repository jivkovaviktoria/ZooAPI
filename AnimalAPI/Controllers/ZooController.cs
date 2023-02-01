using AnimalAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZooController : Controller
    {
        private readonly AnimalsDbContext _context;
        public ZooController(AnimalsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetZoosAsync()
        {
            var zoos = this._context.Zoos.Select(x => new
            {
                id = x.Id,
                Name = x.Name,
                City = x.City,
                Animals = x.Animals.ToList()
            });

            return Ok(zoos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetZooByIdAsync([FromRoute] Guid id)
        {
            var zoo = await this._context.Zoos.FindAsync(id);
            
            if (zoo is null) return NotFound("Id not found");
            return Ok(zoo);
        }

        [HttpGet]
        [Route("Animals/{id:guid}")]
        public async Task<IActionResult> GetZooAnimalsAsync([FromRoute] Guid id)
        {
            var zoo = await this._context.Zoos.FindAsync(id);
            
            if (zoo is null) return NotFound("id not found");

            var animals = zoo.Animals.ToList();
            return Ok(animals);
        }
    }
}
