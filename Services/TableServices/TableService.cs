using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KlassyCafePostgreSql.DAL.Context;
using KlassyCafePostgreSql.DAL.Entities;
using KlassyCafePostgreSql.Dtos.TableDtos;
using Microsoft.EntityFrameworkCore;

namespace KlassyCafePostgreSql.Services.TableServices
{
    public class TableService : ITableService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TableService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void ApprovalChange(int id)
        {
            var value = _context.Tables.Find(id);
            
            if (value != null)
            {
                if (value.TableIsFull)
                {
                    value.TableIsFull = false;
                } else
                {
                    value.TableIsFull = true;
                }
                _context.Tables.Update(value);
                _context.SaveChanges();
            }
        }

        public async Task CreateTableAsync(CreateTableDto createTableDto)
        {
            var value = _mapper.Map<Table>(createTableDto);
            await _context.Tables.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int id)
        {
            var value = await _context.Tables.FindAsync(id);
            _context.Tables.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultTableDto>> GetAllTableAsync()
        {
            var values = await _context.Tables.OrderBy(i => i.TableRow).ToListAsync();
            return _mapper.Map<List<ResultTableDto>>(values);
        }

        public async Task<GetByIdTableDto> GetByIdTableAsync(int id)
        {
            var value = await _context.Tables.FindAsync(id);
            return _mapper.Map<GetByIdTableDto>(value);
        }

        public int TableIsFullCount()
        {
            return _context.Tables.Where(i => i.TableIsFull).Count();
        }

        public async Task UpdateTableAsync(UpdateTableDto updateTableDto)
        {
            var value = _mapper.Map<Table>(updateTableDto);
            _context.Tables.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}