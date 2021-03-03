using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApp.Models
{
    public partial class Customer
    {
        public string Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
