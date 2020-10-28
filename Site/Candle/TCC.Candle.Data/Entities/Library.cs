using System.Collections.Generic;

namespace TCC.Candle.Data.Entities
{
    public class Library : BaseEntity
    {
        public Library()
        {

        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        // UnComment After Implementing ASP.NET Core Identity
        // public Guid UserId { get; set; }



        // Navigational Properties
        public virtual ICollection<Shelf> Shelves { get; set; }
    }
}
