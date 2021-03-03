using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Images
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public string ProductId { get; set; }

        public virtual Products Product { get; set; }
    }
}
