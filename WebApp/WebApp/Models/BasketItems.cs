using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class BasketItems
    {
        public string Id { get; set; }
        public string BasketId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset CreateAt { get; set; }

        public virtual Baskets Basket { get; set; }
    }
}
