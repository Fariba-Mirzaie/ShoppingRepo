using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Functions.Filtering;
using ShoppingAPI.Models;
using ShoppingAPI.Functions.Pagination;
using ShoppingAPI.Repository;
using ShoppingAPI.Functions.Sorting;
using AutoMapper;
using ShoppingAPI.DTO;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;
        public SliderController(ISliderRepository sliderRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IEnumerable<SliderDTO> GetAll([FromQuery] PaginationFilter pagination, [FromQuery] SortingParams sorting, [FromQuery] FilterParams filterparams)
        {
            return _sliderRepository.GetAll(pagination, sorting, filterparams); ;
        }

        [HttpGet("{id}")]
        public SliderDTO Get([FromRoute] int id)
        {
            var slider = _sliderRepository.Get(id);
            var result = _mapper.Map<Slider, SliderDTO>(slider);
            return result;
        }

        [HttpPost]
        public Slider Add(SliderDTO dtoSlider) 
        {
          return  _sliderRepository.Add(dtoSlider);

        }

    }
}
