using System.ComponentModel.DataAnnotations.Schema;
using Vega.Enums;

namespace Vega.Entities
{
    public class Verification : BaseEntity
    {
        public int Code { get; set; }
        public string URL { get; set; }
        public RequestType RequestType { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}