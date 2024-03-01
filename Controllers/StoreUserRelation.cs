using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PopaStore.Data;
using System.Linq;

namespace PopaStore.Controllers
{
    [ApiController]
    [Route("api/storeuserrelations")]
    public class StoreUserRelationController : ControllerBase
    {
        private readonly PopaDBContext _context;

        public StoreUserRelationController(PopaDBContext context)
        {
            _context = context;
        }

        // api/storeuserrelations
        [HttpPost]
        public IActionResult CreateStoreUserRelation([FromBody] StoreUserRelation storeUserRelation)
        {
            if (storeUserRelation == null)
            {
                return BadRequest("Datos de la relación tienda-usuario no proporcionados correctamente.");
            }

            _context.StoreUserRelations.Add(storeUserRelation);
            _context.SaveChanges();

            return Ok("Relación tienda-usuario creada exitosamente.");
        }

        [HttpGet("usersByStore/{storeId}")]
        public IActionResult GetUsersByStore(int storeId)
        {
            var usersFav = _context.StoreUserRelations
                .Where(r => r.StoreId == storeId)
                .Join(
                    _context.Users,
                    relation => relation.UserId,
                    user => user.Id,
                    (relation, user) => new
                    {
                        UserName = user.UserName,
                        UserEmail = user.UserEmail
                    })
                .ToList();

            return Ok(usersFav);
        }







    }
}