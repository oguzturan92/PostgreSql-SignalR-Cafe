using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.DAL.Entities;
using KlassyCafePostgreSql.Dtos.CategoryDtos;

namespace KlassyCafePostgreSql.Services.CategoryServices
{
    public interface ICategoryService
    {
        // ADMİN
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id);
        int CategoryCount();

        // CLIENT
        Task<List<HomeResultCategoryDto>> GetCategoriesAndProducts();
    }
}