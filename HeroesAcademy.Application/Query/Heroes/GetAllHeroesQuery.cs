﻿using HeroesAcademy.Application.Repository.Heroes;
using HeroesAcademy.Domain.Models.Heroes;
using Shared.Models;
using MediatR;

namespace HeroesAcademy.Application.Query.Heroes
{
    public class GetAllHeroesQuery : IRequest<ResponseResult<List<Hero>>>
    {
    }

    public class GetAllHeroesQueryHandler : IRequestHandler<GetAllHeroesQuery, ResponseResult<List<Hero>>>
    {
        private readonly IHeroRepository _heroRepository;

        public GetAllHeroesQueryHandler(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public Task<ResponseResult<List<Hero>>> Handle(GetAllHeroesQuery request, CancellationToken cancellationToken)
        {
            return _heroRepository.Get();
        }
    }
}
