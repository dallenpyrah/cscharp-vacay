using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vacay.Models;
using vacay.Services;

namespace vacay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacationsController : ControllerBase
    {
        private readonly VacationsService _vacaService;

        public VacationsController(VacationsService vacaService)
        {
            _vacaService = vacaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vacation>> GetAll()
        {
            try
            {
                return Ok(_vacaService.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}