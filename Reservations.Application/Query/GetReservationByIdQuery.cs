using HeroesAcademy.Application.Repository.Reservations;
using HeroesAcademy.Domain.Models.Reservations;
using Shared.Models;
using MediatR;

namespace Reservations.Application.Query
{
    public class GetReservationByIdQuery : IRequest<ResponseResult<Reservation>>
    {
        public int Id { get; }
        public GetReservationByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ResponseResult<Reservation>>
    {
        private readonly IReservationRepository _reservationRepository;
        public GetReservationByIdQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<ResponseResult<Reservation?>> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _reservationRepository.GetReservationById(request.Id);
        }
    }
}
