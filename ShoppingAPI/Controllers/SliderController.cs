using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Models;
using ShoppingAPI.Paging;
using ShoppingAPI.Repository;

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
        public IEnumerable<Slider> GetAll(int currentPage, int pageSize)
        {
            var skipCount = (currentPage - 1) * pageSize;
            var totalCount = _sliderRepository.GetAllSlider().Count();
            return _sliderRepository.GetAllSlider().Skip(skipCount).Take(pageSize);

        }
    }
}
