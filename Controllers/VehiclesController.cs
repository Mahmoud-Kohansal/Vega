using System.Threading.Tasks;
using System.Xml.XPath;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Controllers.Resources;
using Vega.Models;
using Vega.Persistence;

namespace Vega.Controllers
{

    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext dbContext;
        public VehiclesController(IMapper mapper, VegaDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;

        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            Vehicle vehicle = this.mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            dbContext.Vehicles.Add(vehicle);
            await dbContext.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }
    }
}