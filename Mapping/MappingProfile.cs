using System.Collections.Generic;
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
            .ForMember(v => v.Id, opt => opt.Ignore())
            .ForMember(v => v.ContactName, opt=> opt.MapFrom(vr=> vr.Contact.Name))
            .ForMember(v => v.ContactPhone, opt=> opt.MapFrom(vr=> vr.Contact.Phone))
            .ForMember(v => v.ContactEmail, opt=> opt.MapFrom(vr=> vr.Contact.Email))
            .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature{FeatureId=id})))
            .AfterMap((vr, v)=>{
                //Remove Unselected Features
                // var removedFeatures = new List<VehicleFeature>();
                // foreach (var f in v.Features)
                // {
                //     if(!vr.Features.Contains(f.FeatureId))
                //     removedFeatures.Add(f);
                // }
                var removedFeatures = v.Features.Where(v => !vr.Features.Contains(v.FeatureId));
                foreach (var f in removedFeatures)
                {
                    v.Features.Remove(f);
                }

                //Add New Feature
                // foreach (var id in vr.Features)
                // {
                //     if(!v.Features.Any(f => f.FeatureId == id))
                //     {
                //         v.Features.Add(new VehicleFeature{FeatureId = id});

                //     }
                // }
                var newFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature{FeatureId = id});
                foreach (var f in newFeatures)
                {
                    v.Features.Add(f);
                }

            });
            ;
        }
    }
}