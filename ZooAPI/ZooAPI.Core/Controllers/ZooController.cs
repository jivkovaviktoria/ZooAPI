using AnimalAPI.Services;
using ZooAPI.Data;
using Microsoft.AspNetCore.Mvc;
using ZooAPI.Data.Common;
using ZooAPI.Data.Models;

namespace ZooAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZooController : Controller
    {
        private readonly IService _zooService;
        public ZooController(ZooDbContext context)
        {
            this._zooService = new ZooService(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetZoos()
        {
            var zoos = this._zooService.Zoos.GetManyAsync();
            return Ok(zoos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetZooById([FromRoute] Guid id)
        {
            var zoo = this._zooService.Zoos.GetAsync(id);
            if (zoo is null) return NotFound(GlobalConstants.ZooNotFound);
            
            return Ok(zoo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Zoo zoo)
        {
            var result = this._zooService.Zoos.CreateAsync(zoo);
            this._zooService.Save();

            if (result == false) return Problem(GlobalConstants.UnsuccessfulOperation);
            return CreatedAtAction(nameof(GetZooById), new {Id = zoo.Id}, zoo);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Zoo zoo)
        {
            var result = this._zooService.Zoos.UpdateAsync(zoo);
            this._zooService.Save();

            if (result == false) return Problem(GlobalConstants.UnsuccessfulOperation);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = this._zooService.Zoos.DeleteAsync(id);
            this._zooService.Save();

            if (result == false) return Problem(GlobalConstants.UnsuccessfulOperation);
            return Ok();
        }
    }
}
