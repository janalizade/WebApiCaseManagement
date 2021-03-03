using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Products
    {
        public Products()
        {
            Images = new HashSet<Images>();
            UserReviews = new HashSet<UserReviews>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacture { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public int Availability { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }

        public virtual ICollection<Images> Images { get; set; }
        public virtual ICollection<UserReviews> UserReviews { get; set; }
    }
}
