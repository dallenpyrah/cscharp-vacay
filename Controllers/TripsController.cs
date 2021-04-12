using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vacay.Models;
using vacay.Services;

namespace vacay.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly TripsService _tripsService;

        public TripsController(TripsService tripsService)
        {
            _tripsService = tripsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Trip>> GetAll()
        {
            try
            {
                return Ok(_tripsService.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Trip> GetOneById(int id)
        {
            try
            {
                return Ok(_tripsService.GetOneById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Trip> CreateOne([FromBody] Trip newTrip)
        {
            try
            {
                return Ok(_tripsService.CreateOne(newTrip));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Trip> EditOne([FromBody] Trip editTrip, int id)
        {
            try
            {
                editTrip.Id = id;
                return Ok(_tripsService.EditOne(editTrip));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Trip> DeleteOne(int id)
        {
            try
            {
                return _tripsService.DeleteOne(id);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}