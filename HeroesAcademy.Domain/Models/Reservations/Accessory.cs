namespace HeroesAcademy.Domain.Models.Reservations
{
    public class Accessory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public Room Room { get; set; }
    }
}