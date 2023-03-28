using HeroesAcademy.Domain.Models.Heroes;
using HeroesAcademy.Domain.Models.Shared;

namespace HeroesAcademy.Application.Repository.Heroes
{
    public interface IHeroRepository
    {
        //Hero Add(Hero hero);
        Task<ResponseResult<List<Hero>>> Get();
        ValueTask<ResponseResult<Hero?>> GetbyId(int id);
        Task<ResponseResult<Hero>> Add(Hero hero);
        Task<bool> Delete(int id);
        Task<ResponseResult<Hero>> Update(int heroId, Hero hero);
    }
}
