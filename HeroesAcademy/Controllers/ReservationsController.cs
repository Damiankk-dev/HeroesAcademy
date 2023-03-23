using HeroesAcademy.Application.Query;
using HeroesAcademy.Domain.Models.Reservations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroesAcademy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : BaseController
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("ByRoom/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Reservation))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Reservation))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(int))]
        public async Task<IActionResult> GetReservationByRoomId(int id)
        {
            var response = await _mediator.Send(new GetReservationByRoomIdQuery(id));
            return OkOrError(response);
        }

        [AllowAnonymous]
        [HttpGet("ByHero/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Reservation))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Reservation))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(int))]
        public async Task<IActionResult> GetResrevationByHeroId(int id)
        {
            var response = await _mediator.Send(new GetReservationByHeroIdQuery(id));
            return OkOrError(response);
        }
    }
}
