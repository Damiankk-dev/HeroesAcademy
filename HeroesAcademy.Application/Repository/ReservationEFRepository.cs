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
    }
}
