using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.ProductDtos;

namespace KlassyCafePostgreSql.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync(int pageSize, int page);
        Task<int> GetAllProductCountAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(int id);
        Task<GetByIdProductDto> GetByIdProductAsync(int id);
        int ProductCount();
    }
}