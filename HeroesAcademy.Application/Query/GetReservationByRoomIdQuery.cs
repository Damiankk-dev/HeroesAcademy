using HeroesAcademy.Application.Repository;
using HeroesAcademy.Domain.Models.Heroes;
using HeroesAcademy.Domain.Models.Reservations;
using MediatR;

namespace HeroesAcademy.Application.Query
{
    public class GetReservationByRoomIdQuery:IRequest<ResponseResult<List<Reservation>>>
    {
        public int Id { get; }

        public GetReservationByRoomIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetByRoomIdQueryHandler : IRequestHandler<GetReservationByRoomIdQuery, ResponseResult<List<Reservation>>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetByRoomIdQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Task<ResponseResult<List<Reservation>>> Handle (GetReservationByRoomIdQuery request, CancellationToken cancellationToken)
        {
            return _reservationRepository.GetReservationByRoomId(request.Id);
        }
    }
}
