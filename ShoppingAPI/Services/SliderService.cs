using ShoppingAPI.Functions.Filtering;
using ShoppingAPI.Models;
using ShoppingAPI.Functions.Pagination;
using ShoppingAPI.Repository;
using ShoppingAPI.Functions.Sorting;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ShoppingAPI.Services
{
    public class SliderService : ISliderRepository
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;
        public SliderService(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<SliderDTO> GetAll(PaginationFilter pagination, SortingParams sorting, FilterParams filtering)
        {
            var query = _context.Sliders.AsQueryable();
            var validFilter = new PaginationFilter(pagination.pageNumber, pagination.pageSize, query.Count());

            if (!string.IsNullOrEmpty(filtering.Title))
                query = query.Where(s => s.Title.Contains(filtering.Title));


            query = sorting.Type switch
            {
                SortingParams.SortType.Asc => query.OrderBy(s => s.SliderId),
                SortingParams.SortType.Desc => query.OrderByDescending(s => s.SliderId)
            };

            query = query.Skip((validFilter.pageNumber - 1) * validFilter.pageSize).Take(validFilter.pageSize);

            var mappSliders = query.ProjectTo<SliderDTO>(_mapper.ConfigurationProvider);
            return mappSliders;
        }

        public Slider Get(int id)
        {
            return _context.Sliders.IgnoreQueryFilters().Where(s => s.SliderId == id).FirstOrDefault();
        }

        public Slider Add(SliderDTO dtoSlider)
        {
            if (dtoSlider != null)
            {
                var mapped = _mapper.Map<SliderDTO, Slider>(dtoSlider);
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
