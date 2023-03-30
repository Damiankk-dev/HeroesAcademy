using HeroesAcademy.Application.Repository.Reservations;
using HeroesAcademy.Domain.Models.Reservations;
using HeroesAcademy.Domain.Models.Shared;
using MediatR;

namespace HeroesAcademy.Application.Commands.Reservations
{
    public class AddReservationCommand : IRequest<ResponseResult<Reservation>>
    {
        public Reservation Reservation { get; }
        public AddReservationCommand(Reservation reservation)
        {
            Reservation = reservation;
        }
    }

    public class AddReservationCommandHandler : IRequestHandler<AddReservationCommand, ResponseResult<Reservation>>
    {
        private readonly IReservationRepository _repository;
        public AddReservationCommandHandler(IReservationRepository repository)
        {
            _repository = repository;
        }
        public Task<ResponseResult<Reservation>> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            return _repository.Add(request.Reservation);
        }
    }
}
