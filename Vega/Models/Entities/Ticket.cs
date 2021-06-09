using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.Entities
{
    public class Ticket : BaseEntity 
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public int TicketAmount { get; set; }

        public virtual User User { get; set; }
    }
}