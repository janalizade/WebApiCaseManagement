using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Baskets
    {
        public Baskets()
        {
            BasketItems = new HashSet<BasketItems>();
        }

        public string Id { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public string CouponName { get; set; }
        public string Delivery { get; set; }
        public string DiscountItemId { get; set; }

        public virtual DiscountItems DiscountItem { get; set; }
        public virtual ICollection<BasketItems> BasketItems { get; set; }
    }
}
