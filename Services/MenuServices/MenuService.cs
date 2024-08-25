using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KlassyCafePostgreSql.DAL.Context;
using KlassyCafePostgreSql.DAL.Entities;
using KlassyCafePostgreSql.Dtos.MenuDtos;
using Microsoft.EntityFrameworkCore;

namespace KlassyCafePostgreSql.Services.MenuServices
{
    public class MenuService : IMenuService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public MenuService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateMenuAsync(CreateMenuDto createMenuDto)
        {
            var value = _mapper.Map<Menu>(createMenuDto);
            await _context.Menus.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuAsync(int id)
        {
            var value = await _context.Menus.FindAsync(id);
            _context.Menus.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultMenuDto>> GetAllMenuAsync()
        {
            var values = await _context.Menus.OrderBy(i => i.MenuRow).ToListAsync();
            return _mapper.Map<List<ResultMenuDto>>(values);
        }

        public async Task<List<ResultMenuDto>> GetAllTrueMenuAsync()
        {
            var values = await _context.Menus.Where(i => i.MenuApproval).OrderBy(i => i.MenuRow).ToListAsync();
            return _mapper.Map<List<ResultMenuDto>>(values);
        }

        public async Task<GetByIdMenuDto> GetByIdMenuAsync(int id)
        {
            var value = await _context.Menus.FindAsync(id);
            return _mapper.Map<GetByIdMenuDto>(value);
        }

        public async Task UpdateMenuAsync(UpdateMenuDto updateMenuDto)
        {
            var value = _mapper.Map<Menu>(updateMenuDto);
            _context.Menus.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}