using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.DTO;
using ShoppingAPI.BaseParameters;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repository
{
    public class SliderRepository : ISliderRepository
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;
        private readonly ISliderParameters _parameters;
        public SliderRepository(MyContext context, IMapper mapper, ISliderParameters sliderParameters)
        {
            _context = context;
            _mapper = mapper;
            _parameters = sliderParameters;
        }

        public IEnumerable<SliderDTO> GetAll(SliderParameters sliderParameters)
        {
            var query = _context.Sliders.AsQueryable();
            //var validFilter = new PaginationFilter(pagination.pageNumber, pagination.pageSize, query.Count());

            _parameters.Pagination(sliderParameters.pageNumber, sliderParameters.pageSize);

            if (!string.IsNullOrEmpty(sliderParameters.Title))
                query = query.Where(s => s.Title.Contains(sliderParameters.Title));


            query = sliderParameters.Type switch
            {
                SliderParameters.SortType.Asc => query.OrderBy(s => s.SliderId),
                SliderParameters.SortType.Desc => query.OrderByDescending(s => s.SliderId)
            };

            query = query.Skip((sliderParameters.pageNumber - 1) * sliderParameters.pageSize).Take(sliderParameters.pageSize);

            var mappSliders = query.ProjectTo<SliderDTO>(_mapper.ConfigurationProvider);
            return mappSliders;

            //query.Select(s => new SliderDTO
            //{
            //    Title = s.Title,
            //    MainImage = s.Image
            //}); == Manual Mapper

        }

        public Slider Get(int id)
        {
            return _context.Sliders.IgnoreQueryFilters().Where(s => s.SliderId == id).FirstOrDefault();
        }

        public Slider Add(SliderDTO sliderDto)
        {
            if (sliderDto != null)
            {
                var mapped = _mapper.Map<SliderDTO, Slider>(sliderDto);
                mapped.CreateDate = DateTime.Now;
                mapped.Description = mapped.Title;

                _context.Sliders.Add(mapped);
                _context.SaveChanges();

                return mapped;
            }
            else
                return null;
        }
    }
}
