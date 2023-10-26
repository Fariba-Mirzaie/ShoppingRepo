using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Functions.Filtering;
using ShoppingAPI.Models;
using ShoppingAPI.Functions.Pagination;
using ShoppingAPI.Repository;
using ShoppingAPI.Functions.Sorting;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderRepository _sliderRepository;
        public SliderController(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        [HttpGet("GetAlSlider")]
        public IEnumerable<Slider> GetAll([FromQuery] PaginationFilter pagination ,[FromQuery] SortingParams sorting , FilterParams filterparams)
        {
            return _sliderRepository.GetAllSlider(pagination , sorting , filterparams);
        }
    }
}
