using System.Linq;
using HotelCachorroApi.Data;
using HotelCachorroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelCachorroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        protected MyDbContext _myDbContext;
        protected DbSet<TbCliente> _dbSetCliente;
        

        public ClienteController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            _dbSetCliente = myDbContext.Set<TbCliente>();          
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            var clientes = _dbSetCliente.Include(o => o.TbCachorros)
            .ToList();
            return Ok(clientes);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetCliente(int id)
        {
            var cliente = _dbSetCliente.Include(o => o.TbCachorros)
                .FirstOrDefault(o => o.IdCliente == id);

            if (cliente != null)
                return Ok(cliente);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult PostCliente([FromBody] TbCliente cliente)
        {
            try
            {
                cliente.IdCliente = 0;

                _dbSetCliente.Add(cliente);

                _myDbContext.SaveChanges();
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { msg = "Erro ao executar operação" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _dbSetCliente.FirstOrDefault(o => o.IdCliente == id);

            if (cliente == null)
                return NoContent();

            _dbSetCliente.Remove(cliente);

            _myDbContext.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutCliente(int id, [FromBody] TbCliente cliente)
        {
            if (_dbSetCliente.Any(o => o.IdCliente == id))
            {
                cliente.IdCliente = id;
                _dbSetCliente.Update(cliente);

                _myDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}