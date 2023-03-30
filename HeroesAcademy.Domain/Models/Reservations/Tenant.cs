using HeroesAcademy.Domain.Models.Heroes;

namespace HeroesAcademy.Domain.Models.Reservations
{
    public class Tenant
    {
        public int Id { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}