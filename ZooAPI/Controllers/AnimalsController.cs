using ZooAPI.Data;
using ZooAPI.Models;
using ZooAPI.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ZooAPI.Controllers;

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
        return Ok(await this._context.Animals.Select(x => new
        {
            Id = x.Id,
            Name = x.Name,
            Age = x.Age,
            Color = x.Color,
            Type = x.Type,
            ZooId  = x.Zoo.Id
        }).ToListAsync());
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetAnimalByIdAsync([FromRoute] Guid id)
    {
        var animal = await this._context.Animals.FindAsync(id);
        if (animal is null) return NotFound("Id not found");

        return Ok(animal);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddAnimalAsync(AnimalAddInputModel animalInputModel)
    {
        var animal = new Animal()
        {
            Id = new Guid(),
            Name = animalInputModel.Name,
            Age = animalInputModel.Age,
            Color = animalInputModel.Color,
            Type = animalInputModel.Type
        };

        await this._context.AddAsync(animal);
        await this._context.SaveChangesAsync();

        return Ok(animal);
    }
    
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateAnimalAsync([FromRoute] Guid id, AnimalAddInputModel animalInputModel)
    {
        var animal = await this._context.Animals.FindAsync(id);

        if (animal is not null)
        {
            animal.Name = animalInputModel.Name;
            animal.Age = animalInputModel.Age;
            animal.Color = animalInputModel.Color;
            animal.Type = animalInputModel.Type;

            await this._context.SaveChangesAsync();
            return Ok(animal);
        }

        return NotFound("Id not found");
    }
    
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteAnimalAsync([FromRoute] Guid id)
    {
        var animal = await this._context.Animals.FindAsync(id);

        if (animal is null) return NotFound("Id not found");

        this._context.Remove(animal);
        await this._context.SaveChangesAsync();

        return Ok(animal);
    }
}
    
    
        
    
    
    