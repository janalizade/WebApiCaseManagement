using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class MembershipTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte ChargeRateOneMonth { get; set; }
        public byte ChargeRateSixMonth { get; set; }
    }
}
