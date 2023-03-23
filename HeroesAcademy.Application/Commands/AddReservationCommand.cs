using HeroesAcademy.Application.Repository;
using HeroesAcademy.Domain.Models.Heroes;
using HeroesAcademy.Domain.Models.Reservations;
using MediatR;

namespace HeroesAcademy.Application.Commands
{
    public class AddReservationCommand:IRequest<ResponseResult<Reservation>>
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
