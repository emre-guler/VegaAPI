using System;

namespace Vega.Entities
{
    public class Gift : BaseEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Photo { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}