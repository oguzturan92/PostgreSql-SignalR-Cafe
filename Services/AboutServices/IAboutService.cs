using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.AboutDtos;

namespace KlassyCafePostgreSql.Services.AboutServices
{
    public interface IAboutService
    {
        // ADMİN
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(int id);
        Task<GetByIdAboutDto> GetByIdAboutAsync(int id);

        // CLIENT
        Task<GetByIdAboutDto> GetByFirstAboutAsync();
    }
}