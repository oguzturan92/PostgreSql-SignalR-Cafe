using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.MenuDtos;

namespace KlassyCafePostgreSql.Services.MenuServices
{
    public interface IMenuService
    {
        // ADMİN
        Task<List<ResultMenuDto>> GetAllMenuAsync();
        Task CreateMenuAsync(CreateMenuDto createMenuDto);
        Task UpdateMenuAsync(UpdateMenuDto updateMenuDto);
        Task DeleteMenuAsync(int id);
        Task<GetByIdMenuDto> GetByIdMenuAsync(int id);

        // CLIENT
        Task<List<ResultMenuDto>> GetAllTrueMenuAsync();
    }
}