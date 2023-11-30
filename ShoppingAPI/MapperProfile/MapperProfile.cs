using AutoMapper;
using ShoppingAPI.DTO;
using ShoppingAPI.Models;

namespace ShoppingAPI.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Slider, SliderDTO>()
                .ReverseMap()
                .ForMember(s => s.Image,
                           dto => dto.MapFrom(s => s.MainImage));

            CreateMap<User , UserDTO>().ReverseMap();

            //CreateMap<IEnumerable<Slider>, IEnumerable<SliderDTO>>().ReverseMap();

                

        }
    }
}
