using System.ComponentModel.DataAnnotations.Schema;
using Vega.Enums;

namespace Vega.Entities
{
    public class TicketQuestion : BaseEntity
    {
        [ForeignKey("TicketId")]
        public int TicketId { get; set; }
        [ForeignKey("QuestionId")]
        public int QuestionId { get; set; }
        public Answer Answer { get; set; }

        
        public virtual Ticket Ticket { get; set; }
        public virtual Question Question { get; set; }
    } 
}