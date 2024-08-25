using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KlassyCafePostgreSql.DAL.Context;
using KlassyCafePostgreSql.DAL.Entities;
using KlassyCafePostgreSql.Dtos.ProductDtos;
using Microsoft.EntityFrameworkCore;

namespace KlassyCafePostgreSql.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ProductService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _context.Products.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var value = await _context.Products.FindAsync(id);
            _context.Products.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync(int pageSize, int page)
        {
            var values = await _context.Products.OrderBy(i => i.ProductRow).Skip((page - 1) * pageSize).Take(pageSize).Include(i => i.Category).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<int> GetAllProductCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(int id)
        {
            var value = await _context.Products.FindAsync(id);
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public int ProductCount()
        {
            return _context.Products.Count();
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _context.Products.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}