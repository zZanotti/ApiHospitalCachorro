using System.Linq;
using HotelCachorroApi.Data;
using HotelCachorroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelCachorroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckinController : ControllerBase
    {
        protected MyDbContext _myDbContext;
        protected DbSet<TbCheckin> _dbSetCheckin;
        

        public CheckinController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            _dbSetCheckin = myDbContext.Set<TbCheckin>();          
        }

        [HttpGet]
        public IActionResult GetCheckins()
        {
            var checkin = _dbSetCheckin.ToList();
            return Ok(checkin);
        }

        [HttpGet("{id}")]
        public IActionResult GetCheckin(int id)
        {
            var checkin = _dbSetCheckin.FirstOrDefault(o => o.IdChekin == id);
            if (checkin != null)
                return Ok(checkin);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult PostCheckin([FromBody] TbCheckin checkin)
        {
            try
            {
                checkin.IdChekin = 0;

                _dbSetCheckin.Add(checkin);

                _myDbContext.SaveChanges();
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { msg = "Erro ao executar operação" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCheckin(int id)
        {
            var checkin = _dbSetCheckin.FirstOrDefault(o => o.IdChekin == id);

            if (checkin == null)
                return NoContent();

            _dbSetCheckin.Remove(checkin);

            _myDbContext.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutCheckin(int id, [FromBody] TbCheckin checkin)
        {
            if (_dbSetCheckin.Any(o => o.IdChekin == id))
            {
                checkin.IdChekin = id;
                _dbSetCheckin.Update(checkin);

                _myDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}