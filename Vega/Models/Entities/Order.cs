using System.ComponentModel.DataAnnotations.Schema;
using Vega.Enums;

namespace Vega.Entities
{
    public class Order : BaseEntity 
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("GiftId")]
        public int GiftId { get; set; }
        public OrderState OrderState { get; set; }


        public virtual Gift Gift { get; set; }
        public virtual User User { get; set; }
    }
}