﻿using HeroesAcademy.Domain.Models.Reservations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservations.Application.Commands;
using Reservations.Application.Query;
using Shared.Controllers;

namespace ReservationsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationsController : BaseController
{
    private readonly IMediator _mediator;

    public ReservationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Reservation))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Reservation))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(int))]
    public async Task<IActionResult> GetReservation(int id)
    {
        var response = await _mediator.Send(new GetReservationByIdQuery(id));
        return OkOrError(response);
    }

    [Authorize]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Reservation))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Reservation))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(int))]
    public async Task<IActionResult> GetReservations()
    {
        var response = await _mediator.Send(new GetReservationsQuery());
        return OkOrError(response);
    }

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

    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Reservation))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Reservation))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddReservation([FromBody] Reservation reservation)
    {
        var response = await _mediator.Send(new AddReservationCommand(reservation));
        return OkOrError(response);
    }

    [Authorize]
    [HttpDelete("{reservationId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(int))]
    public async Task<IActionResult> DeleteReservation(int reservationId)
    {
        var response = await _mediator.Send(new DeleteReservationCommand(reservationId));
        return OkOrError(response);
    }

    [Authorize]
    [HttpPut("{reservationId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(int))]
    public async Task<IActionResult> UpdateReservation([FromBody] Reservation reservation, int reservationId)
    {
        var response = await _mediator.Send(new UpdateReservationCommand(reservationId, reservation));
        return OkOrError(response);
    }
}
