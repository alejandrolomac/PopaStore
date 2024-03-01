using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PopaStore.Data;

namespace PopaStore.Controllers
{
    [ApiController]
    [Route("api/stores")]
    public class StoreController : ControllerBase
    {
        private readonly PopaDBContext _context;

        public StoreController(PopaDBContext context)
        {
            _context = context;
        }

        // POST: api/stores
        [HttpPost]
        public IActionResult CreateStore([FromBody] Store store)
        {
            if (store == null)
            {
                return BadRequest("Datos de la tienda no proporcionados correctamente.");
            }

            _context.Stores.Add(store);
            _context.SaveChanges();

            return CreatedAtAction("GetStoreById", new { id = store.Id }, store);
        }

        // GET: api/stores
        [HttpGet]
        public IActionResult GetStores()
        {
            var stores = _context.Stores.ToList();
            return Ok(stores);
        }

        // GET: api/stores/{id}
        [HttpGet("{id}")]
        public IActionResult GetStoreById(int id)
        {
            var store = _context.Stores.Find(id);

            if (store == null)
            {
                return NotFound("Tienda no encontrada.");
            }

            return Ok(store);
        }
    }


}