using HeroesAcademy.Application.Repository.Reservations;
using HeroesAcademy.Domain.Models.Shared;
using MediatR;

namespace HeroesAcademy.Application.Commands.Reservations
{
    public class DeleteReservationCommand : IRequest<ResponseResult<int>>
    {
        public int ReservationId { get; }
        public DeleteReservationCommand(int reservationId)
        {
            ReservationId = reservationId;
        }
    }

    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, ResponseResult<int>>
    {
        private readonly IReservationRepository _repository;
        public DeleteReservationCommandHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult<int>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var isSuccess = await _repository.Delete(request.ReservationId);
            if (isSuccess)
            {
                return ResponseResult.Ok(request.ReservationId);
            }
            return ResponseResult.NotFound<int>($"Reservation with ID: {request.ReservationId} was not found");
        }
    }
}
