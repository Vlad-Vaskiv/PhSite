using System.Linq;
using AutoMapper;
using PhoneSite.Dtos;
using PhoneSite.Models;

namespace PhoneSite.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
      {
          CreateMap<ModelPhone,ModelForListDto>()
            .ForMember(destination => destination.ImageUrl, opt => {
              opt.MapFrom(src => src.ImagePhones.FirstOrDefault(p => p.isMain).ImageModelAddress);
            });
          CreateMap<ModelPhone,ModelForDetailedDto>()
            .ForMember(destination => destination.ImageUrl, opt => {
              opt.MapFrom(src => src.ImagePhones.FirstOrDefault(p => p.isMain).ImageModelAddress);
            });

       // CreateMap<ImagePhone, ImageForDetailedDto>();
        CreateMap<FirmPhone, FirmForListDto>();
        CreateMap<FirmPhone, ModelForDetailedDto>();
      }
    }
}