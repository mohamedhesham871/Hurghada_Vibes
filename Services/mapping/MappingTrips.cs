using AutoMapper;
using Domain.Enum;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services.mapping
{
    public  class MappingTrips:Profile
    {
       
        public MappingTrips()
        {
            CreateMap<Trips,TripsDto>()
                  .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.ToString()))
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                    .ForMember(dest=>dest.Images,opt=>opt.MapFrom<pictureUrlResolver>());

            CreateMap<TripsDto, Trips>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => Enum.Parse<Locations>(src.Location)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<Status>(src.Status!)));
        }

        public class pictureUrlResolver(IConfiguration _config) : IValueResolver<Trips, TripsDto,List<string>>
        {
            public List<string> Resolve(Trips source, TripsDto destination, List<string> destMember, ResolutionContext context)
            {
                if (!string.IsNullOrWhiteSpace(source.Images.FirstOrDefault()))
                {
                    return source.Images.Select(image => $"{_config["BaseUrl"]}{image}").ToList();
                }
                else
                {
                    return new List<string>();
                }
            }
        }

    }
}
