using HeroesAcademy.Application.Repository.Reservations;
using HeroesAcademy.Domain.Models.Reservations;
using HeroesAcademy.Domain.Models.Shared;
using MediatR;

namespace Reservations.Application.Query
{
    public class GetReservationByHeroIdQuery : IRequest<ResponseResult<List<Reservation>>>
    {
        public int Id { get; }
        public GetReservationByHeroIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetReservationByHeroIdHandler : IRequestHandler<GetReservationByHeroIdQuery, ResponseResult<List<Reservation>>>
    {
        private readonly IReservationRepository _reservationRepository;
        public GetReservationByHeroIdHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public Task<ResponseResult<List<Reservation>>> Handle(GetReservationByHeroIdQuery request, CancellationToken cancellationToken)
        {
            return _reservationRepository.GetReservationByHeroId(request.Id);
        }
    }
}