using System.Linq;
using System.Runtime.InteropServices;
using AutoMapper;
using Vega.Controllers.Resources;
using Vega.Models;

namespace Vega.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Map Domain Class to Api Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>()
            .ForMember(vr => vr.Contact, opt=> opt.MapFrom(vr=> new ContactResource{Name = vr.ContactName, Email= vr.ContactEmail, Phone=vr.ContactPhone}))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(vr => vr.Features.Select(vr => vr.FeatureId)));

            //Map Api Resource to Domain Class
            CreateMap<VehicleResource, Vehicle>()
            .ForMember(v => v.ContactName, opt=> opt.MapFrom(vr=> vr.Contact.Name))
            .ForMember(v => v.ContactPhone, opt=> opt.MapFrom(vr=> vr.Contact.Phone))
            .ForMember(v => v.ContactEmail, opt=> opt.MapFrom(vr=> vr.Contact.Email))
            .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature{FeatureId=id})));
        }
    }
}