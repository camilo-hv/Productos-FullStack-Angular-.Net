using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebApi.Entidades;
using System.Runtime.InteropServices;

namespace MiWebApi.Controllers
{
    [Route("api/laptops")]
    public class LaptopsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LaptopsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<List<Laptop>> Get()
        {
            return await _context.Laptops.ToListAsync();
        }

        [HttpGet("{id:int}", Name = "ObtenerLaptoPorId")]
        public async Task<ActionResult<Laptop>> Get(int id)
        {
            var laptop = await _context.Laptops.FirstOrDefaultAsync(x => x.Id == id);
            if (laptop is null)
            {
                return NotFound();   
            }

            return laptop;
        }

        [HttpPost]
        public async Task<CreatedAtRouteResult> Post(Laptop laptop)
        {
            _context.Add(laptop);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerLaptopPorId", new {id = laptop.Id}, laptop);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Laptop laptop)
        {
            var existeLaptop = await _context.Laptops.AnyAsync(x => x.Id == id);

            if (!existeLaptop)
            {
                return NotFound();
            }

            _context.Update(laptop);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasBorradas = await _context.Laptops.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (filasBorradas == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
