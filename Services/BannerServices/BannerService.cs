using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KlassyCafePostgreSql.DAL.Context;
using KlassyCafePostgreSql.DAL.Entities;
using KlassyCafePostgreSql.Dtos.BannerDtos;
using Microsoft.EntityFrameworkCore;

namespace KlassyCafePostgreSql.Services.BannerServices
{
    public class BannerService : IBannerService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public BannerService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateBannerAsync(CreateBannerDto createBannerDto)
        {
            var value = _mapper.Map<Banner>(createBannerDto);
            await _context.Banners.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBannerAsync(int id)
        {
            var value = await _context.Banners.FindAsync(id);
            _context.Banners.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultBannerDto>> GetAllBannerAsync()
        {
            var values = await _context.Banners.OrderBy(i => i.BannerRow).ToListAsync();
            return _mapper.Map<List<ResultBannerDto>>(values);
        }

        public async Task<List<ResultBannerDto>> GetAllTrueBannerAsync()
        {
            var values = await _context.Banners.Where(i => i.BannerApproval).OrderBy(i => i.BannerRow).ToListAsync();
            return _mapper.Map<List<ResultBannerDto>>(values);
        }

        public async Task<GetByIdBannerDto> GetByIdBannerAsync(int id)
        {
            var value = await _context.Banners.FindAsync(id);
            return _mapper.Map<GetByIdBannerDto>(value);
        }

        public async Task UpdateBannerAsync(UpdateBannerDto updateBannerDto)
        {
            var value = _mapper.Map<Banner>(updateBannerDto);
            _context.Banners.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}