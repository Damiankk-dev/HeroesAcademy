using HeroesAcademy.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroesAcademy.Application.Repository
{
    internal class HeroEFRepository : IHeroRepository
    {
        private readonly HeroesAcademyDbContext _context;

        public HeroEFRepository(HeroesAcademyDbContext context)
        {         
            _context = context??throw new ArgumentNullException(nameof(context));
        }

        //public async Task<ResponseResult>

        public async Task<ResponseResult<Hero>> Add(Hero hero)
        {
            _context.Add(hero);
            await _context.SaveChangesAsync();
            return ResponseResult.Ok(hero);
        }

        public async Task<ResponseResult<List<Hero>>> Get()
        {
            var heroes = await _context.Heroes.ToListAsync();
            return ResponseResult.Ok(heroes);
        }

        public  async ValueTask<ResponseResult<Hero?>> GetbyId(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            return ResponseResult.Ok(hero);
        }

        public async Task<bool> Delete(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return false;
            }
            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ResponseResult<bool>> Update(Hero hero)
        {
            var heroDb = await _context.Heroes.FindAsync(hero.Id);
            if (heroDb == null)
            {
                return ResponseResult.NotFound<bool>("Hero was not found");
            }
            heroDb.Salary= hero.Salary;
            heroDb.Description = hero.Description;
            heroDb.Name = hero.Name;
            heroDb.LogoUrl= hero.LogoUrl;
            heroDb.SecretIdentity= hero.SecretIdentity;
            heroDb.IsActive= hero.IsActive;
            heroDb.Strength = hero.Strength;
            heroDb.Team= hero.Team;

            await _context.SaveChangesAsync();
            return ResponseResult.Ok(true);
            
        }
    }
}
