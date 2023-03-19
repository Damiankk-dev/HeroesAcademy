using HeroesAcademy.Domain.Models.Heroes;

namespace HeroesAcademy.Domain.Models.Reservations
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
        public Tenant Tenant { get; set; }
        public Room Room{ get; set; }
    }
}
