using HeroesAcademy.Application.Repository.Reservations;
using HeroesAcademy.Domain.Models.Reservations;
using Shared.Models;
using MediatR;

namespace Reservations.Application.Query
{
    public class GetReservationsQuery : IRequest<ResponseResult<List<Reservation>>>
    {
    }

    public class GetReservationsQueryHandlaer : IRequestHandler<GetReservationsQuery, ResponseResult<List<Reservation>>>{
        private readonly IReservationRepository _reservationRepository;

        public GetReservationsQueryHandlaer(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Task<ResponseResult<List<Reservation>>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
        {
            return _reservationRepository.GetReservations();
        }
    }
}
