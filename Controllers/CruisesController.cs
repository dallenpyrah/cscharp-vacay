using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vacay.Models;
using vacay.Services;

namespace vacay.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CruisesController : ControllerBase
    {
        private readonly CruisesService _cruiseService;

        public CruisesController(CruisesService cruiseService)
        {
            _cruiseService = cruiseService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cruise>> GetAll()
        {
            try
            {
                return Ok(_cruiseService.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Cruise> GetOneById(int id)
        {
            try
            {
                return Ok(_cruiseService.GetOneById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Cruise> CreateOne([FromBody] Cruise newCruise)
        {
            try
            {
                return Ok(_cruiseService.CreateOne(newCruise));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Cruise> EditOne([FromBody] Cruise edititedCruse, int id)
        {
            try
            {
                edititedCruse.Id = id;
                return Ok(_cruiseService.EditOne(edititedCruse));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Cruise> DeleteOne(int id)
        {
            try
            {
                return Ok(_cruiseService.DeleteOne(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}