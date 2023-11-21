using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Models;
using ShoppingAPI.Repository;
using ShoppingAPI.BaseParameters;
using AutoMapper;
using ShoppingAPI.DTO;
using ShoppingAPI.Services;
using Microsoft.AspNetCore.Cors;

namespace ShoppingAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly ISliderGalleryService _galleryService;
        private readonly IMapper _mapper;
        public SliderController(ISliderService sliderService,ISliderGalleryService galleryService, IMapper mapper)
        {
            _sliderService = sliderService;
            _galleryService = galleryService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IEnumerable<SliderDTO> GetAll([FromQuery] SliderParameters sliderParameters)
        {
            return _sliderService.GetAll(sliderParameters);
        }

        [HttpGet("{id}")]
        public SliderDTO Get([FromRoute] int id)
        {
            return _mapper.Map<Slider, SliderDTO>(_sliderService.Get(id));
        }

        [HttpPost]
        public Slider Add(SliderDTO dtoSlider)
        {
            return _sliderService.Add(dtoSlider);
        }

        [HttpGet("getGallery")]
        public List<SliderGallery> getgallery(int id) 
        {
            var myGallery= _galleryService.GetGroups(id);
            return myGallery;
        }

        [HttpGet("test")]
        public string test() 
        {
            return "it is my test";
        
        }


    }
}
