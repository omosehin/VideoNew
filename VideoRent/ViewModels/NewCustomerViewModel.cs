using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRent.Models;

namespace VideoRent.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //we used this here because we want to be able to iterate and not to access any List method
        public Customer Customer { get; set; }
    }
}