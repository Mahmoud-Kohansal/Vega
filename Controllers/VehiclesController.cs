using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Controllers.Resources;
using Vega.Models;

namespace Vega.Controllers
{

    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        public VehiclesController(IMapper mapper)
        {
            this.mapper = mapper;

        }
        [HttpPost]
        public IActionResult CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            Vehicle vehicle = this.mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            return Ok(vehicle);
        }
    }
}