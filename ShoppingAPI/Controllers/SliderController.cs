﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Models;
using ShoppingAPI.Repository;
using ShoppingAPI.BaseParameters;
using AutoMapper;
using ShoppingAPI.DTO;
using ShoppingAPI.Services;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        //public IEnumerable<SliderDTO> GetAll([FromQuery] PaginationFilter pagination, [FromQuery] SortingParams sorting, [FromQuery] FilterParams filterparams)
        public IEnumerable<SliderDTO> GetAll([FromQuery] SliderParameters sliderParameters)
        
        {
            return _sliderService.GetAll(sliderParameters);
        }

        [HttpGet("{id}")]
        public SliderDTO Get([FromRoute] int id)
        {
            var slider = _sliderService.Get(id);
            var result = _mapper.Map<Slider, SliderDTO>(slider);
            return result;
        }

        [HttpPost]
        public Slider Add(SliderDTO dtoSlider)
        {
            return _sliderService.Add(dtoSlider);
        }

    }
}
