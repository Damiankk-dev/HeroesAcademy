using HeroesAcademy.Domain.Models.Heroes;
using HeroesAcademy.Domain.Models.Reservations;
using Microsoft.EntityFrameworkCore;

namespace HeroesAcademy.Application.Repository
{
    internal class ReservationEFRepository: IReservationRepository
    {
        private readonly HeroesAcademyDbContext _context;

        public ReservationEFRepository(HeroesAcademyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ResponseResult<Reservation>> Add(Reservation reservation)
        {        
            _context.Add(reservation);
            await _context.SaveChangesAsync();
            return ResponseResult.Ok(reservation);
        }

        public async Task<bool> Delete(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation == null)
            {
                return false;
            }
            _context.Remove(reservation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ResponseResult<List<Reservation>>> GetReservationByHeroId(int id)
        {
            var reservations = await _context.Reservations.Where(r => r.TenantId == id).ToListAsync();
            return ResponseResult.Ok(reservations);
        }

        public async Task<ResponseResult<List<Reservation>>> GetReservationByRoomId(int id)
        {
            var reservations = await _context.Reservations.Where(r => r.RoomId == id).ToListAsync();
            return ResponseResult.Ok(reservations);   
        }

        public async Task<ResponseResult<Reservation>> Update(int reservationId, Reservation reservation)
        {
            var reservationDb = await _context.Reservations.FindAsync(reservationId);
            if (reservationDb == null)
            {
                return ResponseResult.NotFound<Reservation>($"Reservation with ID: {reservationId} was not found");
            }
            reservationDb.ReservationStart = reservation.ReservationStart;
            reservationDb.ReservationEnd = reservation.ReservationEnd;
            reservationDb.RoomId = reservation.RoomId;
            reservationDb.TenantId = reservation.TenantId;

            await _context.SaveChangesAsync();

            return ResponseResult.Ok(reservationDb);

        }
    }
}
