using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KlassyCafePostgreSql.DAL.Context;
using KlassyCafePostgreSql.DAL.Entities;
using KlassyCafePostgreSql.Dtos.ReservationDtos;
using Microsoft.EntityFrameworkCore;

namespace KlassyCafePostgreSql.Services.ReservationServices
{
    public class ReservationService : IReservationService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ReservationService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateReservationAsync(CreateReservationDto createReservationDto)
        {
            var value = _mapper.Map<Reservation>(createReservationDto);
            await _context.Reservations.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int id)
        {
            var value = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultReservationDto>> GetAllReservationAsync()
        {
            var values = await _context.Reservations.ToListAsync();
            return _mapper.Map<List<ResultReservationDto>>(values);
        }

        public async Task<GetByIdReservationDto> GetByIdReservationAsync(int id)
        {
            var value = await _context.Reservations.FindAsync(id);
            return _mapper.Map<GetByIdReservationDto>(value);
        }

        public int ReservationCount()
        {
            return _context.Reservations.Count();
        }

        public async Task UpdateReservationAsync(UpdateReservationDto updateReservationDto)
        {
            var value = _mapper.Map<Reservation>(updateReservationDto);
            _context.Reservations.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}