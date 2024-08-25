using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.ReservationDtos;

namespace KlassyCafePostgreSql.Services.ReservationServices
{
    public interface IReservationService
    {
        Task<List<ResultReservationDto>> GetAllReservationAsync();
        Task CreateReservationAsync(CreateReservationDto createReservationDto);
        Task UpdateReservationAsync(UpdateReservationDto updateReservationDto);
        Task DeleteReservationAsync(int id);
        Task<GetByIdReservationDto> GetByIdReservationAsync(int id);
        int ReservationCount();
    }
}