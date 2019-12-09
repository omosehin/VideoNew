using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRent.Models
{
    public class Min18YearsIfAMember :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance; //we cast it because ObjectInstance is an object
            if(customer.MembershipTypeId == 1) //1 is defined in our db
            {

            } 

        }
    }
}