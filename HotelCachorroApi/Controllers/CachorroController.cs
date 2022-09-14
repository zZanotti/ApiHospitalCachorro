using System.Linq;
using HotelCachorroApi.Data;
using HotelCachorroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelCachorroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CachorroController : ControllerBase
    {
        protected MyDbContext _myDbContext;
        protected DbSet<TbCachorro> _dbSetCachorro;
        

        public CachorroController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            _dbSetCachorro = myDbContext.Set<TbCachorro>();          
        }

        [HttpGet]
        public IActionResult GetCachorros()
        {
            var cachorros = _dbSetCachorro.ToList();
            return Ok(cachorros);
        }

        [HttpGet("{id}")]
        public IActionResult GetCachorro(int id)
        {
            var cachorro = _dbSetCachorro.FirstOrDefault(o => o.IdCliente == id);
            if (cachorro != null)
                return Ok(cachorro);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult PostCachorro([FromBody] TbCachorro cachorro)
        {
            try
            {
                cachorro.IdCachorro = 0;

                _dbSetCachorro.Add(cachorro);

                _myDbContext.SaveChanges();
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { msg = "Erro ao executar operação" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCachorro(int id)
        {
            var cachorro = _dbSetCachorro.FirstOrDefault(o => o.IdCachorro == id);

            if (cachorro == null)
                return NoContent();

            _dbSetCachorro.Remove(cachorro);

            _myDbContext.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutCachorro(int id, [FromBody] TbCachorro cachorro)
        {
            if (_dbSetCachorro.Any(o => o.IdCachorro == id))
            {
                cachorro.IdCachorro = id;
                _dbSetCachorro.Update(cachorro);

                _myDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}