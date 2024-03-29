﻿using HeroesAcademy.Application.Commands.Heroes;
using HeroesAcademy.Application.Query.Heroes;
using HeroesAcademy.Domain.Models.Heroes;
using Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Controllers;

namespace HeroesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : BaseController
    {
        private readonly IMediator _mediator;

        public HeroesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Hero>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHeroes()
        {
            var response = await _mediator.Send(new GetAllHeroesQuery());
            return OkOrError(response);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hero))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Hero))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(int))]
        public async Task<IActionResult> GetHeroById(int id)
        {
            var response = await _mediator.Send(new GetHeroByIdQuery(id));
            return OkOrError(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseResult<bool>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseResult<bool>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddHero([FromBody] Hero hero)
        {
            var response = await _mediator.Send(new AddHeroCommand(hero));
            return OkOrError(response);
        }

        [AllowAnonymous]
        [HttpPut("{heroId}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseResult<Hero>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseResult<Hero>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseResult<Hero>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateHero([FromBody] Hero hero, int heroId)
        {
            var response = await _mediator.Send(new UpdateHeroCommand(heroId, hero));
            return OkOrError(response);
        }

        [AllowAnonymous]
        [HttpDelete("{heroId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(int))]
        public async Task<IActionResult> DeleteHero(int heroId)
        {
            var response = await _mediator.Send(new DeleteHeroCommand(heroId));
            return OkOrError(response);
        }
    }
}
