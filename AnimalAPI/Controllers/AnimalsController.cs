using AnimalAPI.Data;
using AnimalAPI.Models;
using AnimalAPI.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : Controller
{
    private readonly AnimalsDbContext _context;

    public AnimalsController(AnimalsDbContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAnimalsAsync()
    {
        return Ok(await this._context.Animals.ToListAsync());
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetAnimalByIdAsync([FromRoute] Guid id)
    {
        var animal = await this._context.Animals.FindAsync(id);
        if (animal is null) return NotFound("Id not found");

        return Ok(animal);
    }
}
    
    
        
    
    
    