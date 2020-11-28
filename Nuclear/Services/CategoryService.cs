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

        public List<CategoryDto> GetAll()
        {
            var categories = _context.Categories.Where(c => c.IsPublic).ToList();
            return _mapper.Map<List<Category>, List<CategoryDto>>(categories);
        }

        public CategoryDto GetCategory(long id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            return _mapper.Map<Category, CategoryDto>(category);
        }

        public List<TopicDto> GetTopicsForCategory(long id)
        {
            var category = _context.Categories
                .Include(c => c.Topics)
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return null;
            }

            return _mapper.Map<Category, CategoryDto>(category).Topics;
        }
    }
}
