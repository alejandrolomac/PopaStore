using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PopaStore.Data;

namespace PopaStore.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly PopaDBContext _context;

        public BrandController(PopaDBContext context)
        {
            _context = context;
        }

        // api/brands
        [HttpPost]
        public IActionResult CreateBrand([FromBody] Brand brand)
        {
            if (brand == null)
            {
                return BadRequest("Datos de la marca no proporcionados correctamente.");
            }

            _context.Brands.Add(brand);
            _context.SaveChanges();

            return CreatedAtAction("GetBrandById", new { id = brand.Id }, brand);
        }

        // api/brands
        [HttpGet]
        public IActionResult GetBrands()
        {
            var brands = _context.Brands.ToList();
            return Ok(brands);
        }

        // api/brands/{id}
        [HttpGet("{id}")]
        public IActionResult GetBrandById(int id)
        {
            var brand = _context.Brands.Find(id);

            if (brand == null)
            {
                return NotFound("Marca no encontrada.");
            }

            return Ok(brand);
        }
    }
}
