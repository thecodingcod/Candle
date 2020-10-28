using System;

namespace TCC.Candle.Data.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
