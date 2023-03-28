using HeroesAcademy.Application.Repository.Reservations;
using HeroesAcademy.Domain.Models.Reservations;
using HeroesAcademy.Domain.Models.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAcademy.Application.Commands.Reservations
{
    public class UpdateReservationCommand : IRequest<ResponseResult<Reservation>>
    {
        public int ReservationId { get; }
        public Reservation Reservation { get; }
        public UpdateReservationCommand(int reservationId, Reservation reservation)
        {
            ReservationId = reservationId;
            Reservation = reservation;
        }
    }

    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, ResponseResult<Reservation>>
    {
        private readonly IReservationRepository _repository;
        public UpdateReservationCommandHandler(IReservationRepository repository)
        {
            _repository = repository;
        }
        public Task<ResponseResult<Reservation>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            return _repository.Update(request.ReservationId, request.Reservation);
        }
    }
}
