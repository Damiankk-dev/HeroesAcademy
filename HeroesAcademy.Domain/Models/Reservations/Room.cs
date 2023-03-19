using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAcademy.Domain.Models.Reservations
{
    public class Room
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public int Volume { get; set; }
        public ICollection<Accessory> Accessories { get; set; }
        public ICollection<Reservation> Reservations{ get; set; }
    }
}
