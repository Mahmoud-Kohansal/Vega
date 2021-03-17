using System;
using System.Threading.Tasks;
using System.Xml.XPath;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Vehicle vehicle = this.mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            dbContext.Vehicles.Add(vehicle);
            await dbContext.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleResource vehicleResource)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Vehicle vehicle = await dbContext.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id );
            this.mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            dbContext.Vehicles.Update(vehicle);
            await dbContext.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }
    }
}