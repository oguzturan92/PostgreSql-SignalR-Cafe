using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KlassyCafePostgreSql.DAL.Context;
using KlassyCafePostgreSql.DAL.Entities;
using KlassyCafePostgreSql.Dtos.CategoryDtos;
using Microsoft.EntityFrameworkCore;

namespace KlassyCafePostgreSql.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CategoryService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int CategoryCount()
        {
            return _context.Categories.Count();
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _context.Categories.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var value = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _context.Categories.OrderBy(i => i.CategoryRow).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            var value = await _context.Categories.FindAsync(id);
            return _mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task<List<HomeResultCategoryDto>> GetCategoriesAndProducts()
        {
            var values = await _context.Categories.Where(i => i.CategoryApproval).OrderBy(i => i.CategoryRow).Include(i => i.Products.OrderBy(i => i.ProductRow)).ToListAsync();
            return _mapper.Map<List<HomeResultCategoryDto>>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _context.Categories.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}