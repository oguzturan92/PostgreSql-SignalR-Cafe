using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.TableDtos;

namespace KlassyCafePostgreSql.Services.TableServices
{
    public interface ITableService
    {
        // ADMİN
        Task<List<ResultTableDto>> GetAllTableAsync();
        Task CreateTableAsync(CreateTableDto createTableDto);
        Task UpdateTableAsync(UpdateTableDto updateTableDto);
        Task DeleteTableAsync(int id);
        Task<GetByIdTableDto> GetByIdTableAsync(int id);
        void ApprovalChange(int id);
        int TableIsFullCount();
        
    }
}