using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KlassyCafePostgreSql.DAL.Context;
using KlassyCafePostgreSql.DAL.Entities;
using KlassyCafePostgreSql.Dtos.AboutDtos;
using Microsoft.EntityFrameworkCore;

namespace KlassyCafePostgreSql.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public AboutService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            await _context.Abouts.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAboutAsync(int id)
        {
            var value = await _context.Abouts.FindAsync(id);
            _context.Abouts.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _context.Abouts.ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task<GetByIdAboutDto> GetByFirstAboutAsync()
        {
            var value = await _context.Abouts.FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(value);
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(int id)
        {
            var value = await _context.Abouts.FindAsync(id);
            return _mapper.Map<GetByIdAboutDto>(value);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            _context.Abouts.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}