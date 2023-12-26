namespace NorthArena.Models
{
    public class Reservation
    {
          public int Id { get; set; }
          public string Name { get; set; }
     

        public decimal Price { get; set; }
        public string Phone { get; set; }
        public String TicketType { get; set; }

        public int FloorORClass { get; set; }
        public string? Room { get; set; }

        public string? ChairNo { get; set; }


    }
}
