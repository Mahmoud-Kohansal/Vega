using Microsoft.AspNetCore.Mvc;
using Vega.Models;

namespace Vega.Controllers
{
    public class VehiclesController:Controller
    {
        public VehiclesController()
        {
            
        }
        [HttpPost("api/vehicles")]
        public IActionResult CreateVehicle([FromBody] Vehicle vehicle)
        {
            return Ok(vehicle);
        }
    }
}