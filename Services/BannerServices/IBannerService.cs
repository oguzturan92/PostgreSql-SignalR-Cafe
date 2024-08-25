using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.BannerDtos;

namespace KlassyCafePostgreSql.Services.BannerServices
{
    public interface IBannerService
    {
        // ADMİN
        Task<List<ResultBannerDto>> GetAllBannerAsync();
        Task CreateBannerAsync(CreateBannerDto createBannerDto);
        Task UpdateBannerAsync(UpdateBannerDto updateBannerDto);
        Task DeleteBannerAsync(int id);
        Task<GetByIdBannerDto> GetByIdBannerAsync(int id);

        // CLIENT
        Task<List<ResultBannerDto>> GetAllTrueBannerAsync();
    }
}