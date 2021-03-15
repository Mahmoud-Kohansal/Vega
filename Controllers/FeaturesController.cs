using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resources;
using Vega.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public FeaturesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("api/features")]
        public async Task<IEnumerable<FeatureResource>> GetFeatures()
        {
            //var makes = await context.Features.Include(m => m.Models).ToListAsync();
            var features = new List<Feature>(){
                new Feature{ Id = 1, Name = "Feature1"},
                new Feature{ Id = 2, Name = "Feature2"}
            };
            return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
    }
}