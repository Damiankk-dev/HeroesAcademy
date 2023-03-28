using HeroesAcademy.Application.Repository.Heroes;
using HeroesAcademy.Domain.Models.Heroes;
using HeroesAcademy.Domain.Models.Shared;
using MediatR;

namespace HeroesAcademy.Application.Commands.Heroes;

public class AddHeroCommand : IRequest<ResponseResult<Hero>>
{
    public Hero Hero { get; }
    public AddHeroCommand(Hero hero)
    {
        Hero = hero;
    }
}

public class AddHeroCommandHandler : IRequestHandler<AddHeroCommand, ResponseResult<Hero>>
{
    private readonly IHeroRepository _repository;

    public AddHeroCommandHandler(IHeroRepository repository)
    {
        _repository = repository;
    }
    public Task<ResponseResult<Hero>> Handle(AddHeroCommand request, CancellationToken cancellationToken)
    {
        return _repository.Add(request.Hero);
    }
}
