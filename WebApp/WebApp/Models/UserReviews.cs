using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class UserReviews
    {
        public string Id { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public string ProductId { get; set; }
        public string UserName { get; set; }

        public virtual Products Product { get; set; }
    }
}
