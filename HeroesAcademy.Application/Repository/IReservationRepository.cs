
using HeroesAcademy.Domain.Models.Heroes;
using HeroesAcademy.Domain.Models.Reservations;

namespace HeroesAcademy.Application.Repository
{
    public interface IReservationRepository
    {
        Task<ResponseResult<List<Reservation>>> GetByRoomId(int id);
        Task<ResponseResult<List<Reservation>>> GetByUserId(int id);
        Task<ResponseResult<Reservation>> Add(Reservation reservation);
        Task<bool> Delete(int id);
        Task<ResponseResult<Reservation>> Update(int id, Reservation reservation);
    }
}
