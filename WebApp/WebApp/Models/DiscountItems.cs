using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class DiscountItems
    {
        public DiscountItems()
        {
            Baskets = new HashSet<Baskets>();
        }

        public string Id { get; set; }
        public string CouponName { get; set; }
        public int Price { get; set; }
        public DateTimeOffset CreateAt { get; set; }

        public virtual ICollection<Baskets> Baskets { get; set; }
    }
}
