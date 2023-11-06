using ShoppingAPI.Models;
using ShoppingAPI.Repository;
using ShoppingAPI.BaseParameters;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ShoppingAPI.Services
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        public SliderService(ISliderRepository repository) => _sliderRepository = repository;

        public Slider Add(SliderDTO sliderDto)
        {
            return _sliderRepository.Add(sliderDto);
        }

        public Slider Get(int id)
        {
            return _sliderRepository.Get(id);
        }

        public IEnumerable<SliderDTO> GetAll(SliderParameters sliderParameters)
        {
            return _sliderRepository.GetAll(sliderParameters);
        }
    }
}
