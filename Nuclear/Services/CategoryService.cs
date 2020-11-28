using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nuclear.Dtos.Category;
using Nuclear.Dtos.Topic;
using Nuclear.EntityFramework;
using Nuclear.EntityFramework.Models;

namespace Nuclear.Services
{
    public class CategoryService
    {
        private readonly NuclearContext _context;
        private readonly IMapper _mapper;

        public CategoryService(NuclearContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories.Where(c => c.IsPublic).ToListAsync();
            return _mapper.Map<List<Category>, List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryAsync(long id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<Category, CategoryDto>(category);
        }

        public async Task<List<TopicDto>> GetTopicsForCategoryAsync(long id)
        {
            var category = await _context.Categories
                .Include(c => c.Topics)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return null;
            }

            return _mapper.Map<Category, CategoryDto>(category).Topics;
        }
    }
}
