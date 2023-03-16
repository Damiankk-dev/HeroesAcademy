using HeroesAcademy.Domain.Models;

namespace HeroesAcademy.Application.Repository
{
    public interface IHeroRepository
    {
        //Hero Add(Hero hero);
        Task<ResponseResult<List<Hero>>> Get();
        ValueTask<ResponseResult<Hero?>> GetbyId(int id);
        Task<ResponseResult<Hero>> Add(Hero hero);
        Task<bool> Delete(int id);
        Task<ResponseResult<bool>> Update(Hero hero);
    }
}

//    public class HeroRepository : IHeroRepository
//    {

//        private Hero[] _heroes = new Hero[] {
//            new()
//            {
//                    Id = 1,
//                    Name = "Iron Man",
//                    Team = "Avengers",
//                    SecretIdentity = "Tony Stark",
//                    Salary = 0.99m,
//                    Description = "Man with iron suit",
//                    Strength = 4.2,
//                    LogoUrl = "assets/logos/iron-man.png"
//            },
//                new(){
//                    Id = 2,
//                    Name= "Thor",
//                    Team= "Avengers",
//                    SecretIdentity= "Thor Odinson",
//                    Salary= 10.99m,
//                    Description= "Norse god of thunder",
//                    Strength= 4.5,
//                    LogoUrl= "assets/logos/thor.png"
//                },
//                new (){
//                    Id= 3,
//                    Name= "Superman",
//                    Team= "Justice League",
//                    SecretIdentity= "Clark Kent",
//                    Salary= 3500,
//                    Description= "Man of steel",
//                    Strength= 5.0,
//                    LogoUrl= "assets/logos/superman.png"
//                },
//                new (){
//                    Id= 4,
//                    Name= "Deadpool",
//                    Team= "X-men",
//                    SecretIdentity= "Wade Wilson",
//                    Salary= 15000,
//                    Description= "Fun to hang out with ... in short doses",
//                    Strength= 3.2,
//                    LogoUrl= "assets/logos/deadpool.png"
//                },
//                new (){
//                    Id= 5,
//                    Name= "Wonder Woman",
//                    Team= "Justice League",
//                    SecretIdentity= "Diana z Themysciry",
//                    Salary= 10000,
//                    Description= "Amazon warrior",
//                    Strength= 4.4,
//                    LogoUrl= "assets/logos/wonder-woman.png"
//                }
//        };
//        public IEnumerable<Hero> Get()
//        {
//            return _heroes;
//        }
//        public Hero GetbyId(int id)
//        {
//            return Array.Find(_heroes, x => x.Id == id);
//        }
//    }
//}
