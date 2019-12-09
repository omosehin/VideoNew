using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoRent.Models
{
    public class MembershipType
    {
        public byte Id { get; set; } //int because we have fee membershiptype 

        public string Name { get; set; }
        public short SignUpFee { get; set; } //short becuse max fee is 32k
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}