using HeroesAcademy.Application.Repository;
using HeroesAcademy.Domain.Models.Heroes;
using HeroesAcademy.Domain.Models.Reservations;
using MediatR;

namespace HeroesAcademy.Application.Query
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