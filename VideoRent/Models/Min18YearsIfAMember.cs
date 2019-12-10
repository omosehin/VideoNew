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
            if(customer.MembershipTypeId == MembershipType.Unknown
                ||customer.MembershipTypeId == MembershipType.PayAsYouGo) //1 is defined in our db
            {
                return ValidationResult.Success;
            }
            if(customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year; //we map to value because birthdate is nullable
            return (age >= 18
                ? ValidationResult.Success
                : new ValidationResult("Customer should be atleast 18years old on a membership"));
        }
    }
}