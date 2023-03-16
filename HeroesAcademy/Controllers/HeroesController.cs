using HeroesAcademy.Application.Commands;
using HeroesAcademy.Application.Query;
using HeroesAcademy.Application.Repository;
using HeroesAcademy.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace HeroesAcademy.Controllers
{
    [Route("api/[controller]")]//api/heroes
    [ApiController]
    public class HeroesController : BaseController
    {
        private readonly IMediator _mediator;
        public HeroesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IHeroRepository _heroRepository;
        public HeroesController(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetHeroes()
        {
            var response = await _mediator.Send(new GetAllHeroesQuery());
            return Ok(await _heroRepository.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(Hero))]
        [ProducesResponseType(StatusCodes.Status400BadRequest,Type=typeof(Hero))]
        [ProducesResponseType(StatusCodes.Status404NotFound,Type=typeof(int))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type=typeof(int))]
        public async Task<IActionResult> GetHeroById(int id)
        {
            var response = await _mediator.Send(new GetHeroByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddHero([FromBody] Hero hero)
        {
            var response = await _mediator.Send(new AddHeroCommand(hero));
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHero(int id )
        {
            if (!await _heroRepository.Delete(id))
            {
                return NotFound(id);//jak inne bledy, to typ z bledami, response result
            }
            return Ok(id);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHero([FromBody] Hero hero)
        {          
            return OkOrError(await _heroRepository.Update(hero));
        }
    }
}
